using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class SearchContextInstancesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var contextInstanceSearch = new ContextInstanceSearch(
            filter: "{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}",
            sort: "-ts",
            limit: 10,
            continuationToken: "QAGFKH1313KUGI2351"
        );

        try
        {
            var response = new ContextsApi(config).SearchContextInstances(
                projectKey: null,
                environmentKey: null,
                contextInstanceSearch: contextInstanceSearch,
                limit: null,
                continuationToken: null,
                sort: null,
                filter: null,
                includeTotalCount: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Contexts#SearchContextInstances: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
