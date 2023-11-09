using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace csl.ni.OpenAI.IntegrationTests;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var openAIApiKey = config["OpenAIConfiguration:OpenAIApiKey"]?.ToString();
        var openAIOrganization = config["OpenAIConfiguration:OpenAIOrganization"]?.ToString();

        services.AddSingleton<OpenAIConfiguration>(new OpenAIConfiguration()
        {
            OpenAIApiKey = openAIApiKey,
            OpenAIOrganization = openAIOrganization
        });

        services.AddSingleton<ChatClient>();
    }
}

