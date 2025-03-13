using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateFlagImportConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var flagImportConfigurationPost = new FlagImportConfigurationPost(
            config: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "environmentId": "The ID of the environment in the external system",
                    "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
                    "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
                    "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
                    "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
                    "workspaceApiKey": "An API key with read permissions in the external feature management system",
                    "workspaceId": "The ID of the workspace in the external system"
                }
            """),
            name: "Sample configuration",
            tags: [
                "example-tag",
            ]
        );

        try
        {
            var response = new FlagImportConfigurationsBetaApi(config).CreateFlagImportConfiguration(
                projectKey: "projectKey_string",
                integrationKey: "integrationKey_string",
                flagImportConfigurationPost: flagImportConfigurationPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FlagImportConfigurationsBetaApi#CreateFlagImportConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
