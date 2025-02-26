using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchTriggerWorkflowExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var flagTriggerInput = new FlagTriggerInput(
            comment: "optional comment",
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "disableTrigger"
                    }
                ]
            """)
        );

        try
        {
            var response = new FlagTriggersApi(config).PatchTriggerWorkflow(
                projectKey: null,
                environmentKey: null,
                featureFlagKey: null,
                id: null,
                flagTriggerInput: flagTriggerInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FlagTriggersApi#PatchTriggerWorkflow: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
