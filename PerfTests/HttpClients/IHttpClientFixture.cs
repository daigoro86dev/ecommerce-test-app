using System.Net.Http;
using NBomber.Contracts;

namespace PerfTests.HttpClients
{
    public interface IHttpClientFixture
    {
        HttpClient GetHttpClient();
        Response GetResponseStatusCode(HttpResponseMessage response);
    }
}