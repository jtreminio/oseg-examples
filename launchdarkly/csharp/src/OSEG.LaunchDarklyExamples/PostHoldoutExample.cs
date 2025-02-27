using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostHoldoutExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var metrics1 = new MetricInput(
            key: "metric-key-123abc",
            isGroup: true,
            primary: true
        );

        var metrics = new List<MetricInput>
        {
            metrics1,
        };

        var holdoutPostRequest = new HoldoutPostRequest(
            name: "holdout-one-name",
            key: "holdout-key",
            description: "My holdout-one description",
            randomizationunit: "user",
            holdoutamount: "10",
            primarymetrickey: "metric-key-123abc",
            prerequisiteflagkey: "flag-key-123abc",
            maintainerId: null,
            attributes: [
                "country",
                "device",
                "os",
            ],
            metrics: metrics
        );

        try
        {
            var response = new HoldoutsBetaApi(config).PostHoldout(
                projectKey: null,
                environmentKey: null,
                holdoutPostRequest: holdoutPostRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HoldoutsBetaApi#PostHoldout: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
