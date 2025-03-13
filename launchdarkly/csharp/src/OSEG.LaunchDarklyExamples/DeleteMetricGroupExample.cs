using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteMetricGroupExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            new MetricsBetaApi(config).DeleteMetricGroup(
                projectKey: null,
                metricGroupKey: null
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MetricsBetaApi#DeleteMetricGroup: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
