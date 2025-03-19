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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var addNewAgentToAccountRequest = new AddNewAgentToAccountRequest(
            email: "email_string",
            name: "name_string",
            role: AddNewAgentToAccountRequest.RoleEnum.Agent
        );

        try
        {
            var response = new AgentsApi(config).AddNewAgentToAccount(
                accountId: 0,
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
