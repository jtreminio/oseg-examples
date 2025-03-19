using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchAIConfigExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var aIConfigPatch = new AIConfigPatch(
            description: "description",
            name: "name",
            tags: [
                "tags",
                "tags",
            ]
        );

        try
        {
            var response = new AIConfigsBetaApi(config).PatchAIConfig(
                lDAPIVersion: "beta",
                projectKey: "projectKey_string",
                configKey: "configKey_string",
                aIConfigPatch: aIConfigPatch
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AIConfigsBetaApi#PatchAIConfig: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
