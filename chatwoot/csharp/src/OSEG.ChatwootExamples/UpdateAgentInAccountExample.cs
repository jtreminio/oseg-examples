using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateAgentInAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var updateAgentInAccountRequest = new UpdateAgentInAccountRequest(
            role: null,
            availability: null,
            autoOffline: null
        );

        try
        {
            var response = new AgentsApi(config).UpdateAgentInAccount(
                accountId: null,
                id: null,
                data: updateAgentInAccountRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AgentsApi#UpdateAgentInAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
