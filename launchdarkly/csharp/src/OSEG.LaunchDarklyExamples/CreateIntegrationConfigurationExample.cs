using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateIntegrationConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var capabilityConfigAuditLogEventsHookStatements1 = new StatementPost(
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

        var capabilityConfigAuditLogEventsHookStatements = new List<StatementPost>
        {
            capabilityConfigAuditLogEventsHookStatements1,
        };

        var capabilityConfigApprovalsAdditionalFormVariables = new List<FormVariable>();

        var capabilityConfigApprovals = new ApprovalsCapabilityConfig(
            additionalFormVariables: capabilityConfigApprovalsAdditionalFormVariables
        );

        var capabilityConfigAuditLogEventsHook = new AuditLogEventsHookCapabilityConfigPost(
            statements: capabilityConfigAuditLogEventsHookStatements
        );

        var capabilityConfig = new CapabilityConfigPost(
            approvals: capabilityConfigApprovals,
            auditLogEventsHook: capabilityConfigAuditLogEventsHook
        );

        var integrationConfigurationPost = new IntegrationConfigurationPost(
            name: "Example integration configuration",
            configValues: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "optional": "an optional property",
                    "required": "the required property",
                    "url": "https://example.com"
                }
            """),
            enabled: true,
            tags: [
                "ops",
            ],
            capabilityConfig: capabilityConfig
        );

        try
        {
            var response = new IntegrationsBetaApi(config).CreateIntegrationConfiguration(
                integrationKey: null,
                integrationConfigurationPost: integrationConfigurationPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationsBetaApi#CreateIntegrationConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
