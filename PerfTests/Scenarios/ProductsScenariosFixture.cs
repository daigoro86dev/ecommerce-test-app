using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBomber.Contracts;
using PerfTests.Steps;

namespace PerfTests.Scenarios
{
    public class ProductsScenariosFixture : ScenarioFixture, IProductsScenariosFixture
    {
        private readonly IProductsStepsFixture _stepsFixture;

        public ProductsScenariosFixture(IProductsStepsFixture stepsFixture)
        {
            _stepsFixture = stepsFixture;
        }

        public Scenario GetAllProducstScenario()
            => this.SetupScenario("Get All Products Scenario", _stepsFixture.GetAllProducts());

        public Scenario GetProductByIdScenario()
            => this.SetupScenario("Get Product By Id Scenario", _stepsFixture.GetProductById(1));

    }
}