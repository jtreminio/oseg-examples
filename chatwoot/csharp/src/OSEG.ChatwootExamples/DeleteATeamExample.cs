using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteATeamExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["platformAppApiKey"] = "PLATFORM_APP_API_KEY"};

        try
        {
            new TeamsApi(config).DeleteATeam(
                accountId: null,
                teamId: null
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsApi#DeleteATeam: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
