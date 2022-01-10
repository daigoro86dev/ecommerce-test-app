using System.Net.Http;
using NBomber.Contracts;

namespace PerfTests.HttpClients
{
    public interface IHttpClientFixture
    {
        HttpClient SetClient();
        Response GetResponseStatusCode(HttpResponseMessage response);
    }
}