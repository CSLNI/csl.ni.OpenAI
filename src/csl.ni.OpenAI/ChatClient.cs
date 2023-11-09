using csl.ni.OpenAI.Base;
using csl.ni.OpenAI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace csl.ni.OpenAI
{
    public class ChatClient
    {
        private readonly AuthorizedHttpClient _authorizedHttpClient;
        public ChatClient(OpenAIConfiguration configuration)
        {
            _authorizedHttpClient = new AuthorizedHttpClient(configuration);
        }
        public ChatClient(OpenAIConfiguration configuration, HttpClient httpClient)
        {
            _authorizedHttpClient = new AuthorizedHttpClient(configuration, httpClient);
        }
        public Task<ChatResponse> SendAsync(ChatRequest chatRequest) => throw new NotImplementedException();
    }
}
