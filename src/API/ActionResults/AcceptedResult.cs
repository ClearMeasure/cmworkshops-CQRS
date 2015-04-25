using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace LightSail.Api.ActionResults
{
    public class AcceptedResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly Uri _uri;

        public AcceptedResult(HttpRequestMessage request)
        {
            _request = request;
        }

        public AcceptedResult(HttpRequestMessage request, Uri uri)
        {
            _request = request;
            _uri = uri;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Accepted);
            if (_uri != null)
            {
                response.Headers.Location = _uri;
            }
            return Task.FromResult(response);
        }
    }
}