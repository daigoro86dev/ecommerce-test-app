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
        [Trait("Products", "Perf")]
        [InlineData(20, 5)]
        public void GetAllProductsTest(int rate, int seconds)
        {
            var scenario = _productScenariosFixture.GetAllProducstScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rate, during: TimeSpan.FromSeconds(seconds))
                });

            var nodeStats = NBomberRunner.RegisterScenarios(scenario).Run();
            var stepStats = nodeStats.ScenarioStats[0].StepStats[0];

            stepStats.Ok.Request.Count.Should().Be(rate * seconds);
        }

        [Theory]
        [InlineData(20, 5)]
        public void GetProductById(int rate, int seconds)
        {
            var scenario = _productScenariosFixture.GetProductByIdScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rate, during: TimeSpan.FromSeconds(seconds))
                });

            var nodeStats = NBomberRunner.RegisterScenarios(scenario).Run();
            var stepStats = nodeStats.ScenarioStats[0].StepStats[0];

            stepStats.Ok.Request.Count.Should().Be(rate * seconds);
        }
    }
}