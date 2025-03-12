using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewAgentToTeamExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var addNewAgentToTeamRequest = new AddNewAgentToTeamRequest(
            userIds: [
            ]
        );

        try
        {
            var response = new TeamsApi(config).AddNewAgentToTeam(
                accountId: null,
                teamId: null,
                data: addNewAgentToTeamRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsApi#AddNewAgentToTeam: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
