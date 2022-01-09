using NBomber.Contracts;
using NBomber.CSharp;
using PerfTests.HttpClients;

namespace PerfTests.Steps
{
    public class StepFixture : IStepFixture
    {
        private readonly IHttpClientFixture _httpClient;

        public StepFixture(IHttpClientFixture httpClient)
        {
            _httpClient = httpClient;
        }

        public IStep GetAllProductsStep()
        {
            var client = _httpClient.GetHttpClient();

            return Step.Create("Get All Products", async context =>
            {
                var response = await client.GetAsync("http://localhost:5000/api/products", context.CancellationToken);

                return _httpClient.GetResponseStatusCode(response);
            });
        }
    }
}