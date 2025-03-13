using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostMigrationSafetyIssuesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var flagSempatch = new FlagSempatch(
            instructions: new List<Dictionary<string, object>>()
        );

        try
        {
            var response = new FeatureFlagsApi(config).PostMigrationSafetyIssues(
                projectKey: "projectKey_string",
                flagKey: "flagKey_string",
                environmentKey: "environmentKey_string",
                flagSempatch: flagSempatch
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlagsApi#PostMigrationSafetyIssues: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
