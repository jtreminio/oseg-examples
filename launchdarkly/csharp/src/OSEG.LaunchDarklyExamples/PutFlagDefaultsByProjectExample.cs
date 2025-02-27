using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutFlagDefaultsByProjectExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var booleanDefaults = new BooleanFlagDefaults(
            trueDisplayName: "True",
            falseDisplayName: "False",
            trueDescription: "serve true",
            falseDescription: "serve false",
            onVariation: 0,
            offVariation: 1
        );

        var defaultClientSideAvailability = new DefaultClientSideAvailability(
            usingMobileKey: true,
            usingEnvironmentId: true
        );

        var upsertFlagDefaultsPayload = new UpsertFlagDefaultsPayload(
            temporary: true,
            tags: [
                "tag-1",
                "tag-2",
            ],
            booleanDefaults: booleanDefaults,
            defaultClientSideAvailability: defaultClientSideAvailability
        );

        try
        {
            var response = new ProjectsApi(config).PutFlagDefaultsByProject(
                projectKey: null,
                upsertFlagDefaultsPayload: upsertFlagDefaultsPayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ProjectsApi#PutFlagDefaultsByProject: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
