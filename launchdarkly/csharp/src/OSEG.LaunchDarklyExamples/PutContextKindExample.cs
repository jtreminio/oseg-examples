using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutContextKindExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var upsertContextKindPayload = new UpsertContextKindPayload(
            name: "organization",
            description: "An example context kind for organizations",
            hideInTargeting: false,
            archived: false,
            varVersion: 1
        );

        try
        {
            var response = new ContextsApi(config).PutContextKind(
                projectKey: null,
                key: null,
                upsertContextKindPayload: upsertContextKindPayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContextsApi#PutContextKind: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
