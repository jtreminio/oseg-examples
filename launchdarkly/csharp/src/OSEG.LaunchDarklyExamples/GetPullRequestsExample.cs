using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class GetPullRequestsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new InsightsPullRequestsBetaApi(config).GetPullRequests(
                projectKey: "projectKey_string",
                environmentKey: null,
                applicationKey: null,
                status: null,
                query: null,
                limit: null,
                expand: null,
                sort: null,
                from: DateTime.Parse("None"),
                to: DateTime.Parse("None"),
                after: null,
                before: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InsightsPullRequestsBetaApi#GetPullRequests: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
