using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchExperimentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var experimentPatchInput = new ExperimentPatchInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "kind": "updateName",
                        "value": "Updated experiment name"
                    }
                ]
            """),
            comment: "Example comment describing the update"
        );

        try
        {
            var response = new ExperimentsApi(config).PatchExperiment(
                projectKey: null,
                environmentKey: null,
                experimentKey: null,
                experimentPatchInput: experimentPatchInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Experiments#PatchExperiment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
