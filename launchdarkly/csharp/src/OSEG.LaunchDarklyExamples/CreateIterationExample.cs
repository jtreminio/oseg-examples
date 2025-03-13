using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateIterationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var treatments1Parameters1 = new TreatmentParameterInput(
            flagKey: "example-flag-for-experiment",
            variationId: "e432f62b-55f6-49dd-a02f-eb24acf39d05"
        );

        var treatments1Parameters = new List<TreatmentParameterInput>
        {
            treatments1Parameters1,
        };

        var metrics1 = new MetricInput(
            key: "metric-key-123abc",
            isGroup: true,
            primary: true
        );

        var metrics = new List<MetricInput>
        {
            metrics1,
        };

        var treatments1 = new TreatmentInput(
            name: "Treatment 1",
            baseline: true,
            allocationPercent: "10",
            parameters: treatments1Parameters
        );

        var treatments = new List<TreatmentInput>
        {
            treatments1,
        };

        var iterationInput = new IterationInput(
            hypothesis: "Example hypothesis, the new button placement will increase conversion",
            flags: null,
            canReshuffleTraffic: true,
            primarySingleMetricKey: "metric-key-123abc",
            primaryFunnelKey: "metric-group-key-123abc",
            randomizationUnit: "user",
            attributes: [
                "country",
                "device",
                "os",
            ],
            metrics: metrics,
            treatments: treatments
        );

        try
        {
            var response = new ExperimentsApi(config).CreateIteration(
                projectKey: null,
                environmentKey: null,
                experimentKey: null,
                iterationInput: iterationInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ExperimentsApi#CreateIteration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
