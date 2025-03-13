using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostRelayAutoConfigExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var policy1 = new Statement(
            effect: Statement.EffectEnum.Allow,
            resources: [
                "proj/*:env/*",
            ],
            actions: [
                "*",
            ]
        );

        var policy = new List<Statement>
        {
            policy1,
        };

        var relayAutoConfigPost = new RelayAutoConfigPost(
            name: "Sample Relay Proxy config for all proj and env",
            policy: policy
        );

        try
        {
            var response = new RelayProxyConfigurationsApi(config).PostRelayAutoConfig(
                relayAutoConfigPost: relayAutoConfigPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling RelayProxyConfigurationsApi#PostRelayAutoConfig: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
