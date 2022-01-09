using System.Net.Http;
using System.Threading.Tasks;
using NBomber.Contracts;

namespace PerfTests.HttpClients
{
    public class HttpClientFixture : IHttpClientFixture
    {
        public HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            return httpClient;
        }

        public Response GetResponseStatusCode(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode
                ? Response.Ok(statusCode: (int)response.StatusCode)
                : Response.Fail(statusCode: (int)response.StatusCode);
        }
    }
}