using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteAgentInTeamExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var deleteAgentInTeamRequest = new DeleteAgentInTeamRequest(
            userIds: [
            ]
        );

        try
        {
            new TeamsApi(config).DeleteAgentInTeam(
                accountId: 0,
                teamId: 0,
                data: deleteAgentInTeamRequest
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsApi#DeleteAgentInTeam: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
