using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostAIConfigExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var aIConfigPost = new AIConfigPost(
            key: "key",
            name: "name",
            description: "",
            tags: [
                "tags",
                "tags",
            ]
        );

        try
        {
            var response = new AIConfigsBetaApi(config).PostAIConfig(
                lDAPIVersion: "beta",
                projectKey: "projectKey_string",
                aIConfigPost: aIConfigPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AIConfigsBetaApi#PostAIConfig: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
