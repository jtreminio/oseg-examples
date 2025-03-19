using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostTeamExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var teamPostInput = new TeamPostInput(
            key: "team-key-123abc",
            name: "Example team",
            description: "An example team",
            customRoleKeys: [
                "example-role1",
                "example-role2",
            ],
            memberIDs: [
                "12ab3c45de678910fgh12345",
            ]
        );

        try
        {
            var response = new TeamsApi(config).PostTeam(
                teamPostInput: teamPostInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling TeamsApi#PostTeam: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
