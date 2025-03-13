using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class GetFlagEventsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new InsightsFlagEventsBetaApi(config).GetFlagEvents(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                applicationKey: null,
                query: null,
                impactSize: null,
                hasExperiments: null,
                global: null,
                expand: null,
                limit: null,
                from: null,
                to: null,
                after: null,
                before: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsFlagEventsBetaApi#GetFlagEvents: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
