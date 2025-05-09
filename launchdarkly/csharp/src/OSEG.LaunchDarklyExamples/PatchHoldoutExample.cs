using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchHoldoutExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var holdoutPatchInput = new HoldoutPatchInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "updateName",
                        "value": "Updated holdout name"
                    }
                ]
            """),
            comment: "Optional comment describing the update"
        );

        try
        {
            var response = new HoldoutsBetaApi(config).PatchHoldout(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                holdoutKey: "holdoutKey_string",
                holdoutPatchInput: holdoutPatchInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HoldoutsBetaApi#PatchHoldout: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
