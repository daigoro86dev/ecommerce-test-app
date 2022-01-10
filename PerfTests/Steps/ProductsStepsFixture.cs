using NBomber.Contracts;
using NBomber.CSharp;
using PerfTests.HttpClients;

namespace PerfTests.Steps
{
    public class ProductsStepsFixture : IProductsStepsFixture
    {
        private readonly IHttpClientFixture _httpClient;

        public ProductsStepsFixture(IHttpClientFixture httpClient)
        {
            _httpClient = httpClient;
        }

        public IStep GetAllProducts()
        {
            return Step.Create("Get All Products", async context =>
            {
                var response =
                    await _httpClient.SetClient().GetAsync("http://localhost:5000/api/products", context.CancellationToken);

                return _httpClient.GetResponseStatusCode(response);
            });
        }

        public IStep GetProductById(int id)
        {
            return Step.Create("Get Product By Id", async context =>
            {
                var response =
                    await _httpClient.SetClient().GetAsync($"http://localhost:5000/api/products/{id}", context.CancellationToken);

                return _httpClient.GetResponseStatusCode(response);
            });
        }
    }
}