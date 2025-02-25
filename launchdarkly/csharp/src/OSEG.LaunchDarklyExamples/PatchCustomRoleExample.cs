using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchCustomRoleExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var patch1 = new PatchOperation(
            op: "add",
            path: "/policy/0"
        );

        var patch = new List<PatchOperation>
        {
            patch1,
        };

        var patchWithComment = new PatchWithComment(
            patch: patch
        );

        try
        {
            var response = new CustomRolesApi(config).PatchCustomRole(
                customRoleKey: null,
                patchWithComment: patchWithComment
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CustomRoles#PatchCustomRole: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
