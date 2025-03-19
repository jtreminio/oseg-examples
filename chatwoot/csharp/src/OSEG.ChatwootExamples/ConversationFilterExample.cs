using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class ConversationFilterExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var conversationFilterRequest = new ConversationFilterRequest(
            payload: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "attribute_key": "browser_language",
                        "filter_operator": "not_eq",
                        "query_operator": "AND",
                        "values": [
                            "en"
                        ]
                    },
                    {
                        "attribute_key": "status",
                        "filter_operator": "eq",
                        "query_operator": null,
                        "values": [
                            "pending"
                        ]
                    }
                ]
            """)
        );

        try
        {
            var response = new ConversationsApi(config).ConversationFilter(
                accountId: 0,
                body: conversationFilterRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsApi#ConversationFilter: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
