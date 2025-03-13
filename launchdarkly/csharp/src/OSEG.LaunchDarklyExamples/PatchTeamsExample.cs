using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchTeamsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var teamsPatchInput = new TeamsPatchInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "addMembersToTeams",
                        "memberIDs": [
                            "1234a56b7c89d012345e678f"
                        ],
                        "teamKeys": [
                            "example-team-1",
                            "example-team-2"
                        ]
                    }
                ]
            """),
            comment: "Optional comment about the update"
        );

        try
        {
            var response = new TeamsBetaApi(config).PatchTeams(
                teamsPatchInput: teamsPatchInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsBetaApi#PatchTeams: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
