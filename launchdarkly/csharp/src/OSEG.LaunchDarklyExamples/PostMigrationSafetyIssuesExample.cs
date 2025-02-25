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
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var flagSempatch = new FlagSempatch(
            instructions: new List<Dictionary<string, object>>(),
            comment: null
        );

        try
        {
            var response = new FeatureFlagsApi(config).PostMigrationSafetyIssues(
                projectKey: null,
                flagKey: null,
                environmentKey: null,
                flagSempatch: flagSempatch
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlags#PostMigrationSafetyIssues: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
