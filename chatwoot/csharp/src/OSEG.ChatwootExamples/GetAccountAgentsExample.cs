using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class GetAccountAgentsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        try
        {
            var response = new AgentsApi(config).GetAccountAgents(
                accountId: 0
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AgentsApi#GetAccountAgents: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
