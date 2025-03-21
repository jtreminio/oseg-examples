using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class EvaluateContextInstanceExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new ContextsApi(config).EvaluateContextInstance(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                requestBody: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                    {
                        "key": "user-key-123abc",
                        "kind": "user",
                        "otherAttribute": "other attribute value"
                    }
                """)
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContextsApi#EvaluateContextInstance: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
