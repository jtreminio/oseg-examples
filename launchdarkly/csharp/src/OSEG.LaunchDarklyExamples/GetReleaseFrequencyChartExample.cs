using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class GetReleaseFrequencyChartExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new InsightsChartsBetaApi(config).GetReleaseFrequencyChart(
                projectKey: null,
                environmentKey: null,
                applicationKey: null,
                hasExperiments: null,
                global: null,
                groupBy: null,
                from: DateTime.Parse("None"),
                to: DateTime.Parse("None"),
                bucketType: null,
                bucketMs: null,
                expand: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsChartsBetaApi#GetReleaseFrequencyChart: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
