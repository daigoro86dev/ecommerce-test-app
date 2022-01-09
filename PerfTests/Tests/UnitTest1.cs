using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NBomber.Contracts;
using NBomber.CSharp;
using PerfTests.Scenarios;
using PerfTests.Steps;
using Xunit;
using Xunit.Abstractions;

namespace PerfTests.Tests
{
    // in this example we use:
    // - XUnit (https://xunit.net/)
    // - Fluent Assertions (https://fluentassertions.com/)
    // to get more info about test automation, please visit: (https://nbomber.com/docs/test-automation)

    public class XUnitTest
    {
        private readonly IStepFixture _stepFixture;
        private readonly IScenarioFixture _scenarioFixture;
        private readonly ITestOutputHelper _outputHelper;

        public XUnitTest(IStepFixture stepFixture, IScenarioFixture scenarioFixture, ITestOutputHelper outputHelper)
        {
            _stepFixture = stepFixture;
            _scenarioFixture = scenarioFixture;
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Test()
        {
            var step = _stepFixture.GetAllProductsStep();

            var scenario = _scenarioFixture.SetupScenario("Test Scenario", step)
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.KeepConstant(copies: 10, during: TimeSpan.FromSeconds(5))
                });

            var nodeStats = NBomberRunner.RegisterScenarios(scenario).Run();
            var stepStats = nodeStats.ScenarioStats[0].StepStats[0];

            _outputHelper.WriteLine(nodeStats.ToString());
        }
    }
}