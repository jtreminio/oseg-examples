using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateAgentsInInboxExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var updateAgentsInInboxRequest = new UpdateAgentsInInboxRequest(
            inboxId: null,
            userIds: [
            ]
        );

        try
        {
            var response = new InboxesApi(config).UpdateAgentsInInbox(
                accountId: null,
                data: updateAgentsInInboxRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxesApi#UpdateAgentsInInbox: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
