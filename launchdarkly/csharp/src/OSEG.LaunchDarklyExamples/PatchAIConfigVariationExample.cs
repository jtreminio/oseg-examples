using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchAIConfigVariationExample
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

        var aIConfigVariationPatch = new AIConfigVariationPatch(
            modelConfigKey: "modelConfigKey",
            name: "name",
            published: true,
            model: new Dictionary<string, object>(),
            messages: messages
        );

        try
        {
            var response = new AIConfigsBetaApi(config).PatchAIConfigVariation(
                lDAPIVersion: "beta",
                projectKey: "projectKey_string",
                configKey: "configKey_string",
                variationKey: "variationKey_string",
                aIConfigVariationPatch: aIConfigVariationPatch
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AIConfigsBetaApi#PatchAIConfigVariation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
