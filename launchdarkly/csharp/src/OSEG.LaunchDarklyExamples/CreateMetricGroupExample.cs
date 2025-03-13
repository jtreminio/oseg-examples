using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateMetricGroupExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var metrics1 = new MetricInMetricGroupInput(
            key: "metric-key-123abc",
            nameInGroup: "Step 1"
        );

        var metrics = new List<MetricInMetricGroupInput>
        {
            metrics1,
        };

        var metricGroupPost = new MetricGroupPost(
            key: "metric-group-key-123abc",
            name: "My metric group",
            kind: MetricGroupPost.KindEnum.Funnel,
            maintainerId: "569fdeadbeef1644facecafe",
            tags: [
                "ops",
            ],
            description: "Description of the metric group",
            metrics: metrics
        );

        try
        {
            var response = new MetricsBetaApi(config).CreateMetricGroup(
                projectKey: null,
                metricGroupPost: metricGroupPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MetricsBetaApi#CreateMetricGroup: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
