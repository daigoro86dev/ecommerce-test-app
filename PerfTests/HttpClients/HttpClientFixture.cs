using System;
using System.Net.Http;
using NBomber.Contracts;

namespace PerfTests.HttpClients
{
    public class HttpClientFixture : IHttpClientFixture
    {
        public HttpClient SetClient()
        {
            var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");

            if (baseUrl == null)
            {
                throw new Exception("Missing BASE_URL env variable");
            }

            return new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public Response GetResponseStatusCode(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode
                ? Response.Ok(statusCode: (int)response.StatusCode, sizeBytes: 1024)
                : Response.Fail(statusCode: (int)response.StatusCode, sizeBytes: 1024);
        }
    }
}

