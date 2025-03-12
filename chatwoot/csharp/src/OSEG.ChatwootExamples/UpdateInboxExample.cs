using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateInboxExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["platformAppApiKey"] = "PLATFORM_APP_API_KEY"};

        var channel = new UpdateInboxRequestChannel(
            websiteUrl: null,
            welcomeTitle: null,
            welcomeTagline: null,
            agentAwayMessage: null,
            widgetColor: null
        );

        var updateInboxRequest = new UpdateInboxRequest(
            enableAutoAssignment: null,
            name: null,
            avatar: null,
            channel: channel
        );

        try
        {
            var response = new InboxesApi(config).UpdateInbox(
                accountId: null,
                id: null,
                data: updateInboxRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxesApi#UpdateInbox: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
