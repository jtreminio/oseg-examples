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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var updateAgentsInInboxRequest = new UpdateAgentsInInboxRequest(
            inboxId: "inbox_id_string",
            userIds: [
            ]
        );

        try
        {
            var response = new InboxesApi(config).UpdateAgentsInInbox(
                accountId: 0,
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
