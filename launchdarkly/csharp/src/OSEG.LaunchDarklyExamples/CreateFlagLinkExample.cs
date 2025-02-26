using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateFlagLinkExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var flagLinkPost = new FlagLinkPost(
            key: "flag-link-key-123abc",
            deepLink: "https://example.com/archives/123123123",
            title: "Example link title",
            description: "Example link description"
        );

        try
        {
            var response = new FlagLinksBetaApi(config).CreateFlagLink(
                projectKey: null,
                featureFlagKey: null,
                flagLinkPost: flagLinkPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FlagLinksBetaApi#CreateFlagLink: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
