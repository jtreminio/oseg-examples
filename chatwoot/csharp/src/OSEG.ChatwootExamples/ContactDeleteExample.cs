using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class ContactDeleteExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");
        // config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        try
        {
            new ContactsApi(config).ContactDelete(
                accountId: 0,
                id: 0
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContactsApi#ContactDelete: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
