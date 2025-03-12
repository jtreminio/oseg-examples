using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class ListAllTeamsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["platformAppApiKey"] = "PLATFORM_APP_API_KEY"};

        try
        {
            var response = new TeamsApi(config).ListAllTeams(
                accountId: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsApi#ListAllTeams: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
