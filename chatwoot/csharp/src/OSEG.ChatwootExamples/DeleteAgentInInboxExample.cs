using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteAgentInInboxExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var deleteAgentInInboxRequest = new DeleteAgentInInboxRequest(
            inboxId: null,
            userIds: [
            ]
        );

        try
        {
            new InboxesApi(config).DeleteAgentInInbox(
                accountId: null,
                data: deleteAgentInInboxRequest
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxesApi#DeleteAgentInInbox: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
