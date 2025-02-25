using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostWebhookExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var statements1 = new StatementPost(
            effect: StatementPost.EffectEnum.Allow,
            resources: [
                "proj/test",
            ],
            actions: [
                "*",
            ]
        );

        var statements = new List<StatementPost>
        {
            statements1,
        };

        var webhookPost = new WebhookPost(
            url: "https://example.com",
            sign: false,
            on: true,
            name: "apidocs test webhook",
            tags: [
                "example-tag",
            ],
            statements: statements
        );

        try
        {
            var response = new WebhooksApi(config).PostWebhook(
                webhookPost: webhookPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Webhooks#PostWebhook: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
