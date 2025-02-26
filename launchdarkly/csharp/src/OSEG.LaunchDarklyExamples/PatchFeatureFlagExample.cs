using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchFeatureFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var patch1 = new PatchOperation(
            op: "replace",
            path: "/description"
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
            var response = new FeatureFlagsApi(config).PatchFeatureFlag(
                projectKey: null,
                featureFlagKey: null,
                patchWithComment: patchWithComment,
                ignoreConflicts: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlagsApi#PatchFeatureFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
