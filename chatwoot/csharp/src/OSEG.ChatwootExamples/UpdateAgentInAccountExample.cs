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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var updateAgentInAccountRequest = new UpdateAgentInAccountRequest(
            role: UpdateAgentInAccountRequest.RoleEnum.Agent
        );

        try
        {
            var response = new AgentsApi(config).UpdateAgentInAccount(
                accountId: 0,
                id: 0,
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
