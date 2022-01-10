using System.Net.Http;
using System.Threading.Tasks;
using NBomber.Contracts;

namespace PerfTests.HttpClients
{
    public class HttpClientFixture : IHttpClientFixture
    {
        public HttpClient SetClient() => new HttpClient();

        public Response GetResponseStatusCode(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode
                ? Response.Ok(statusCode: (int)response.StatusCode, sizeBytes: 1024)
                : Response.Fail(statusCode: (int)response.StatusCode, sizeBytes: 1024);
        }
    }
}