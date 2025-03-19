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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");
        // config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        var inboxCreationRequest = new InboxCreationRequest(
        );

        try
        {
            var response = new InboxesApi(config).InboxCreation(
                accountId: 0,
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
