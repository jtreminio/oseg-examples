using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchFlagConfigScheduledChangeExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var flagScheduledChangesInput = new FlagScheduledChangesInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "replaceScheduledChangesInstructions",
                        "value": [
                            {
                                "kind": "turnFlagOff"
                            }
                        ]
                    }
                ]
            """),
            comment: "Optional comment describing the update to the scheduled changes"
        );

        try
        {
            var response = new ScheduledChangesApi(config).PatchFlagConfigScheduledChange(
                projectKey: "projectKey_string",
                featureFlagKey: "featureFlagKey_string",
                environmentKey: "environmentKey_string",
                id: "id_string",
                flagScheduledChangesInput: flagScheduledChangesInput,
                ignoreConflicts: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ScheduledChangesApi#PatchFlagConfigScheduledChange: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
