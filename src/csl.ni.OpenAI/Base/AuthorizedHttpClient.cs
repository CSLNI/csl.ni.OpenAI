using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csl.ni.OpenAI.Base
{
    internal class AuthorizedHttpClient
    {
        private readonly OpenAIConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AuthorizedHttpClient(OpenAIConfiguration configuration)
        {
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _ = configuration.OpenAIApiKey ?? throw new ArgumentNullException($"{nameof(OpenAIConfiguration)}.{nameof(OpenAIConfiguration.OpenAIApiKey)}");
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public AuthorizedHttpClient(OpenAIConfiguration configuration, HttpClient httpClient)
        {
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _ = configuration.OpenAIApiKey ?? throw new ArgumentNullException($"{nameof(OpenAIConfiguration)}.{nameof(OpenAIConfiguration.OpenAIApiKey)}");
            _ = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SendAuthorizedAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _configuration.OpenAIApiKey);
            return _httpClient.SendAsync(request, cancellationToken);
        }
    }
}
