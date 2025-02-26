using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateSubscriptionExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var statements1 = new StatementPost(
            effect: StatementPost.EffectEnum.Allow,
            resources: [
                "proj/*:env/*:flag/*;testing-tag",
            ],
            actions: [
                "*",
            ]
        );

        var statements = new List<StatementPost>
        {
            statements1,
        };

        var subscriptionPost = new SubscriptionPost(
            name: "Example audit log subscription.",
            config: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "optional": "an optional property",
                    "required": "the required property",
                    "url": "https://example.com"
                }
            """),
            on: false,
            tags: [
                "testing-tag",
            ],
            statements: statements
        );

        try
        {
            var response = new IntegrationAuditLogSubscriptionsApi(config).CreateSubscription(
                integrationKey: null,
                subscriptionPost: subscriptionPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationAuditLogSubscriptionsApi#CreateSubscription: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
