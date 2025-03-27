using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class NewConversationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var messageTemplateParams = new NewConversationRequestMessageTemplateParams(
            name: "sample_issue_resolution",
            category: "UTILITY",
            language: "en_US",
            processedParams: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "1": "Chatwoot"
                }
            """)
        );

        var message = new NewConversationRequestMessage(
            content: "content_string",
            templateParams: messageTemplateParams
        );

        var newConversationRequest = new NewConversationRequest(
            inboxId: "inbox_id_string",
            sourceId: "source_id_string",
            customAttributes: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "attribute_key": "attribute_value",
                    "priority_conversation_number": 3
                }
            """),
            message: message
        );

        try
        {
            var response = new ConversationsApi(config).NewConversation(
                accountId: 0,
                data: newConversationRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsApi#NewConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
