using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateExperimentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var iterationTreatments1Parameters1 = new TreatmentParameterInput(
            flagKey: "example-flag-for-experiment",
            variationId: "e432f62b-55f6-49dd-a02f-eb24acf39d05"
        );

        var iterationTreatments1Parameters = new List<TreatmentParameterInput>
        {
            iterationTreatments1Parameters1,
        };

        var iterationMetrics1 = new MetricInput(
            key: "metric-key-123abc",
            isGroup: true,
            primary: true
        );

        var iterationMetrics = new List<MetricInput>
        {
            iterationMetrics1,
        };

        var iterationTreatments1 = new TreatmentInput(
            name: "Treatment 1",
            baseline: true,
            allocationPercent: "10",
            parameters: iterationTreatments1Parameters
        );

        var iterationTreatments = new List<TreatmentInput>
        {
            iterationTreatments1,
        };

        var iteration = new IterationInput(
            hypothesis: "Example hypothesis, the new button placement will increase conversion",
            flags: new Dictionary<string, object>(),
            canReshuffleTraffic: true,
            primarySingleMetricKey: "metric-key-123abc",
            primaryFunnelKey: "metric-group-key-123abc",
            randomizationUnit: "user",
            attributes: [
                "country",
                "device",
                "os",
            ],
            metrics: iterationMetrics,
            treatments: iterationTreatments
        );

        var experimentPost = new ExperimentPost(
            name: "Example experiment",
            key: "experiment-key-123abc",
            description: "An example experiment, used in testing",
            maintainerId: "12ab3c45de678910fgh12345",
            holdoutId: "f3b74309-d581-44e1-8a2b-bb2933b4fe40",
            iteration: iteration
        );

        try
        {
            var response = new ExperimentsApi(config).CreateExperiment(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                experimentPost: experimentPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ExperimentsApi#CreateExperiment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
