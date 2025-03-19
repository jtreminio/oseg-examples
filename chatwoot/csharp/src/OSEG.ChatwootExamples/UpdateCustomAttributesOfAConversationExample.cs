using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateCustomAttributesOfAConversationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var updateCustomAttributesOfAConversationRequest = new UpdateCustomAttributesOfAConversationRequest(
            customAttributes: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "order_id": "12345",
                    "previous_conversation": "67890"
                }
            """)
        );

        try
        {
            var response = new ConversationsApi(config).UpdateCustomAttributesOfAConversation(
                accountId: 0,
                conversationId: 0,
                data: updateCustomAttributesOfAConversationRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsApi#UpdateCustomAttributesOfAConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
