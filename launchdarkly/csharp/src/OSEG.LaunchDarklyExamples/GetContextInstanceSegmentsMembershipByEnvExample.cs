using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class GetContextInstanceSegmentsMembershipByEnvExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new SegmentsApi(config).GetContextInstanceSegmentsMembershipByEnv(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                requestBody: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                    {
                        "address": {
                            "city": "Springfield",
                            "street": "123 Main Street"
                        },
                        "jobFunction": "doctor",
                        "key": "context-key-123abc",
                        "kind": "user",
                        "name": "Sandy"
                    }
                """)
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SegmentsApi#GetContextInstanceSegmentsMembershipByEnv: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
