using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostCustomRoleExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var policy1 = new StatementPost(
            effect: StatementPost.EffectEnum.Allow,
            resources: [
                "proj/*:env/production:flag/*",
            ],
            actions: [
                "updateOn",
            ]
        );

        var policy = new List<StatementPost>
        {
            policy1,
        };

        var customRolePost = new CustomRolePost(
            name: "Ops team",
            key: "role-key-123abc",
            description: "An example role for members of the ops team",
            basePermissions: "reader",
            policy: policy
        );

        try
        {
            var response = new CustomRolesApi(config).PostCustomRole(
                customRolePost: customRolePost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CustomRoles#PostCustomRole: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
