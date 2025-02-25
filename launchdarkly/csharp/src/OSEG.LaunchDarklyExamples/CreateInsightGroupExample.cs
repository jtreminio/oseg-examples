using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateInsightGroupExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var postInsightGroupParams = new PostInsightGroupParams(
            name: "Production - All Apps",
            key: "default-production-all-apps",
            projectKey: "default",
            environmentKey: "production",
            applicationKeys: [
                "billing-service",
                "inventory-service",
            ]
        );

        try
        {
            var response = new InsightsScoresBetaApi(config).CreateInsightGroup(
                postInsightGroupParams: postInsightGroupParams
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsScoresBeta#CreateInsightGroup: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
