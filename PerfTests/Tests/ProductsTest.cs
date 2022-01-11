using System;
using FluentAssertions;
using NBomber.CSharp;
using PerfTests.Scenarios;
using Xunit;
using Xunit.Abstractions;

namespace PerfTests.Tests
{
    public class ProductsTest
    {
        private readonly IProductsScenariosFixture _productScenariosFixture;
        private readonly ITestOutputHelper _outputHelper;

        public ProductsTest(IProductsScenariosFixture productScenariosFixture, ITestOutputHelper outputHelper)
        {
            _productScenariosFixture = productScenariosFixture;
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(25, 5)]
        public void GetAllProductsTest(int rate, int seconds)
        {
            var getProductsScenario = _productScenariosFixture.GetAllProducstScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rate, during: TimeSpan.FromSeconds(seconds))
                });

            var getProductByIdScenario = _productScenariosFixture.GetProductByIdScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rate, during: TimeSpan.FromSeconds(seconds))
                });

            var nodeStats = NBomberRunner.RegisterScenarios(getProductsScenario, getProductByIdScenario).Run();
            var stepStats = nodeStats.ScenarioStats;

            foreach (var productScenario in stepStats)
            {
                productScenario.StepStats[0].Ok.Request.Count.Should().Be(rate * seconds);
            }
        }
    }
}