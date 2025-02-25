using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateTriggerWorkflowExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var triggerPost = new TriggerPost(
            integrationKey: "generic-trigger",
            comment: "example comment",
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "turnFlagOn"
                    }
                ]
            """)
        );

        try
        {
            var response = new FlagTriggersApi(config).CreateTriggerWorkflow(
                projectKey: null,
                environmentKey: null,
                featureFlagKey: null,
                triggerPost: triggerPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FlagTriggers#CreateTriggerWorkflow: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
