using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostMemberTeamsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var memberTeamsPostInput = new MemberTeamsPostInput(
            teamKeys: [
                "team1",
                "team2",
            ]
        );

        try
        {
            var response = new AccountMembersApi(config).PostMemberTeams(
                id: null,
                memberTeamsPostInput: memberTeamsPostInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountMembersApi#PostMemberTeams: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
