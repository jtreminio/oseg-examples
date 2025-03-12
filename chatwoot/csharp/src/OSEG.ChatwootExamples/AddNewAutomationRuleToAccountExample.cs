using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewAutomationRuleToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var automationRuleCreateUpdatePayload = new AutomationRuleCreateUpdatePayload(
            name: "Add label on message create event",
            description: "Add label support and sales on message create event if incoming message content contains text help",
            eventName: AutomationRuleCreateUpdatePayload.EventNameEnum.MessageCreated,
            active: null
        );

        try
        {
            var response = new AutomationRuleApi(config).AddNewAutomationRuleToAccount(
                accountId: null,
                data: automationRuleCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AutomationRuleApi#AddNewAutomationRuleToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
