using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostAuditLogEntriesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var statementPost1 = new StatementPost(
            effect: StatementPost.EffectEnum.Allow,
            resources: [
                "proj/*:env/*:flag/*;testing-tag",
            ],
            notResources: [
            ],
            actions: [
                "*",
            ],
            notActions: [
            ]
        );

        var statementPost = new List<StatementPost>
        {
            statementPost1,
        };

        try
        {
            var response = new AuditLogApi(config).PostAuditLogEntries(
                statementPost: statementPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AuditLogApi#PostAuditLogEntries: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
