using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostMetricExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var metricPost = new MetricPost(
            key: "metric-key-123abc",
            kind: MetricPost.KindEnum.Custom,
            isActive: true,
            isNumeric: false,
            eventKey: "trackedClick"
        );

        try
        {
            var response = new MetricsApi(config).PostMetric(
                projectKey: null,
                metricPost: metricPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MetricsApi#PostMetric: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
