using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostModelConfigExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var modelConfigPost = new ModelConfigPost(
            id: "id",
            key: "key",
            name: "name",
            icon: "icon",
            provider: "provider",
            tags: [
                "tags",
                "tags",
            ],
            varParams: new Dictionary<string, object>(),
            customParams: new Dictionary<string, object>()
        );

        try
        {
            var response = new AIConfigsBetaApi(config).PostModelConfig(
                lDAPIVersion: ModelConfigPost.LDAPIVersionEnum.Beta,
                projectKey: "default",
                modelConfigPost: modelConfigPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AIConfigsBetaApi#PostModelConfig: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
