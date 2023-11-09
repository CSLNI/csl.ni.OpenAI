namespace csl.ni.OpenAI.IntegrationTests;

public class ChatClientTests
{
    private readonly ChatClient _chatClient;

    public ChatClientTests(ChatClient chatClient)
    {
        _chatClient = chatClient ?? throw new ArgumentNullException(nameof(chatClient));
    }

    [Fact]
    public async Task SayThisIsATest()
    {
        var chatRequest = new ChatRequest();
        chatRequest.Model = "gpt-3.5-turbo";
        chatRequest.Messages.Add(new(Role.System, "You are a helpful assistant."));
        chatRequest.FrequencyPenalty = -1.5f;
        chatRequest.LogitBias.Add(new("Hello how are you?", -100));
        chatRequest.MaxTokens = 1000;
        chatRequest.NumberOfChoices = 10;
        chatRequest.PresencePenalty = -1.5f;
        chatRequest.ResponseFormatJson = true;
        chatRequest.Seed = 15000;
        chatRequest.Stop = "";
        chatRequest.Stream = false;
        chatRequest.Temperature = 0.8f;
        chatRequest.TopP = 0.5f;
        chatRequest.Tools.Add(new Function());


        var response = await _chatClient.SendAsync(chatRequest);


        int a = 1;
    }
}