using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class InboxCreationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["platformAppApiKey"] = "PLATFORM_APP_API_KEY"};

        var channel = new InboxCreationRequestChannel(
            type: null,
            websiteUrl: null,
            welcomeTitle: null,
            welcomeTagline: null,
            agentAwayMessage: null,
            widgetColor: null
        );

        var inboxCreationRequest = new InboxCreationRequest(
            name: null,
            avatar: null,
            channel: channel
        );

        try
        {
            var response = new InboxesApi(config).InboxCreation(
                accountId: null,
                data: inboxCreationRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxesApi#InboxCreation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
