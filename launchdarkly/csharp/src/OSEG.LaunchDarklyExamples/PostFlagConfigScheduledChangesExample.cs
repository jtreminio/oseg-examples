using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostFlagConfigScheduledChangesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var postFlagScheduledChangesInput = new PostFlagScheduledChangesInput(
            executionDate: 1718467200000,
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "turnFlagOn"
                    }
                ]
            """),
            comment: "Optional comment describing the scheduled changes"
        );

        try
        {
            var response = new ScheduledChangesApi(config).PostFlagConfigScheduledChanges(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                postFlagScheduledChangesInput: postFlagScheduledChangesInput,
                ignoreConflicts: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ScheduledChanges#PostFlagConfigScheduledChanges: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
