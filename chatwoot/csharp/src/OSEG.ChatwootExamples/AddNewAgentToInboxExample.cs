using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewAgentToInboxExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var addNewAgentToInboxRequest = new AddNewAgentToInboxRequest(
            inboxId: "inbox_id_string",
            userIds: [
            ]
        );

        try
        {
            var response = new InboxesApi(config).AddNewAgentToInbox(
                accountId: 0,
                data: addNewAgentToInboxRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxesApi#AddNewAgentToInbox: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
