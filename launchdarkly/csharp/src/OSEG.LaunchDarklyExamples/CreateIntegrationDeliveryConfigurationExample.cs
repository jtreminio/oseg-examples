using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateIntegrationDeliveryConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var integrationDeliveryConfigurationPost = new IntegrationDeliveryConfigurationPost(
            config: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "optional": "example value for optional formVariables property for sample-integration",
                    "required": "example value for required formVariables property for sample-integration"
                }
            """),
            on: false,
            name: "Sample integration",
            tags: [
                "example-tag",
            ]
        );

        try
        {
            var response = new IntegrationDeliveryConfigurationsBetaApi(config).CreateIntegrationDeliveryConfiguration(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                integrationKey: "integrationKey_string",
                integrationDeliveryConfigurationPost: integrationDeliveryConfigurationPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationDeliveryConfigurationsBetaApi#CreateIntegrationDeliveryConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
