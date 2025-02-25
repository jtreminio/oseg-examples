using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchExpiringTargetsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var patchFlagsRequest = new PatchFlagsRequest(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "addExpireUserTargetDate",
                        "userKey": "sandy",
                        "value": 1686412800000,
                        "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
                    }
                ]
            """),
            comment: "optional comment"
        );

        try
        {
            var response = new FeatureFlagsApi(config).PatchExpiringTargets(
                projectKey: null,
                environmentKey: null,
                featureFlagKey: null,
                patchFlagsRequest: patchFlagsRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlags#PatchExpiringTargets: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
