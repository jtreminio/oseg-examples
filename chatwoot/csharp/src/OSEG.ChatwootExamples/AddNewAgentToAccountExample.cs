using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewAgentToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var addNewAgentToAccountRequest = new AddNewAgentToAccountRequest(
            email: null,
            name: null,
            role: null,
            availabilityStatus: null,
            autoOffline: null
        );

        try
        {
            var response = new AgentsApi(config).AddNewAgentToAccount(
                accountId: null,
                data: addNewAgentToAccountRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AgentsApi#AddNewAgentToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
