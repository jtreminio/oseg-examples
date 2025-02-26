using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CopyFeatureFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var source = new FlagCopyConfigEnvironment(
            key: "source-env-key-123abc",
            currentVersion: 1
        );

        var target = new FlagCopyConfigEnvironment(
            key: "target-env-key-123abc",
            currentVersion: 1
        );

        var flagCopyConfigPost = new FlagCopyConfigPost(
            comment: "optional comment",
            source: source,
            target: target
        );

        try
        {
            var response = new FeatureFlagsApi(config).CopyFeatureFlag(
                projectKey: null,
                featureFlagKey: null,
                flagCopyConfigPost: flagCopyConfigPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlagsApi#CopyFeatureFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
