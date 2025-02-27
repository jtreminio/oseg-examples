using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateDeploymentEventExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var postDeploymentEventInput = new PostDeploymentEventInput(
            projectKey: "default",
            environmentKey: "production",
            applicationKey: "billing-service",
            varVersion: "a90a8a2",
            eventType: PostDeploymentEventInput.EventTypeEnum.Started,
            applicationName: "Billing Service",
            applicationKind: PostDeploymentEventInput.ApplicationKindEnum.Server,
            versionName: "v1.0.0",
            eventTime: 1706701522000,
            eventMetadata: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "buildSystemVersion": "v1.2.3"
                }
            """),
            deploymentMetadata: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "buildNumber": "1234"
                }
            """)
        );

        try
        {
            new InsightsDeploymentsBetaApi(config).CreateDeploymentEvent(
                postDeploymentEventInput: postDeploymentEventInput
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsDeploymentsBetaApi#CreateDeploymentEvent: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
