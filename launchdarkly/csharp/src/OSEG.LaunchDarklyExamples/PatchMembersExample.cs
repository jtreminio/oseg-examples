using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchMembersExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var membersPatchInput = new MembersPatchInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "replaceMembersRoles",
                        "memberIDs": [
                            "1234a56b7c89d012345e678f",
                            "507f1f77bcf86cd799439011"
                        ],
                        "value": "reader"
                    }
                ]
            """),
            comment: "Optional comment about the update"
        );

        try
        {
            var response = new AccountMembersBetaApi(config).PatchMembers(
                membersPatchInput: membersPatchInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountMembersBetaApi#PatchMembers: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
