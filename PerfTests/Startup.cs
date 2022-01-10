using Microsoft.Extensions.DependencyInjection;
using PerfTests.HttpClients;
using PerfTests.Scenarios;
using PerfTests.Steps;

namespace PerfTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientFixture, HttpClientFixture>();
            services.AddScoped<IProductsStepsFixture, ProductsStepsFixture>();
            services.AddScoped<IScenarioFixture, ScenarioFixture>();
            services.AddScoped<IProductsScenariosFixture, ProductsScenariosFixture>();
        }
    }
}