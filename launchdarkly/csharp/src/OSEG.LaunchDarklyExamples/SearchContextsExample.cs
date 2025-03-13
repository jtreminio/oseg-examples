using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class SearchContextsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var contextSearch = new ContextSearch(
            filter: "*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]",
            sort: "-ts",
            limit: 10,
            continuationToken: "QAGFKH1313KUGI2351"
        );

        try
        {
            var response = new ContextsApi(config).SearchContexts(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                contextSearch: contextSearch,
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
            Console.WriteLine("Exception when calling ContextsApi#SearchContexts: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
