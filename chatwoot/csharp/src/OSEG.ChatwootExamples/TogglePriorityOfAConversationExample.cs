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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var togglePriorityOfAConversationRequest = new TogglePriorityOfAConversationRequest(
            priority: TogglePriorityOfAConversationRequest.PriorityEnum.Urgent
        );

        try
        {
            new ConversationsApi(config).TogglePriorityOfAConversation(
                accountId: 0,
                conversationId: 0,
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
