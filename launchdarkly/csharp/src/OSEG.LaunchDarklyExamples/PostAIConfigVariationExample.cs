using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostAIConfigVariationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var messages1 = new Message(
            content: "content",
            role: "role"
        );

        var messages2 = new Message(
            content: "content",
            role: "role"
        );

        var messages = new List<Message>
        {
            messages1,
            messages2,
        };

        var aIConfigVariationPost = new AIConfigVariationPost(
            key: "key",
            name: "name",
            model: new Dictionary<string, object>(),
            modelConfigKey: "modelConfigKey",
            messages: messages
        );

        try
        {
            var response = new AIConfigsBetaApi(config).PostAIConfigVariation(
                lDAPIVersion: "beta",
                projectKey: "projectKey_string",
                configKey: "configKey_string",
                aIConfigVariationPost: aIConfigVariationPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AIConfigsBetaApi#PostAIConfigVariation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
