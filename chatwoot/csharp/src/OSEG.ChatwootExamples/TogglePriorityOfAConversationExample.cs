using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class TogglePriorityOfAConversationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};

        var togglePriorityOfAConversationRequest = new TogglePriorityOfAConversationRequest(
            priority: null
        );

        try
        {
            new ConversationsApi(config).TogglePriorityOfAConversation(
                accountId: null,
                conversationId: null,
                data: togglePriorityOfAConversationRequest
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsApi#TogglePriorityOfAConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
