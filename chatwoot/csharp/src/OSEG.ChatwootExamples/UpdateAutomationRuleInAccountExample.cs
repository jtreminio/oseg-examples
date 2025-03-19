using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateAutomationRuleInAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var automationRuleCreateUpdatePayload = new AutomationRuleCreateUpdatePayload(
            name: "Add label on message create event",
            description: "Add label support and sales on message create event if incoming message content contains text help",
            eventName: AutomationRuleCreateUpdatePayload.EventNameEnum.MessageCreated,
            actions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "action_name": "add_label",
                        "action_params": [
                            "support"
                        ]
                    }
                ]
            """),
            conditions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "attribute_key": "content",
                        "filter_operator": "contains",
                        "query_operator": "nil",
                        "values": [
                            "help"
                        ]
                    }
                ]
            """)
        );

        try
        {
            var response = new AutomationRuleApi(config).UpdateAutomationRuleInAccount(
                accountId: 0,
                id: 0,
                data: automationRuleCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AutomationRuleApi#UpdateAutomationRuleInAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
