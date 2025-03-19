using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateConversationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var updateConversationRequest = new UpdateConversationRequest(
        );

        try
        {
            new ConversationsApi(config).UpdateConversation(
                accountId: 0,
                conversationId: 0,
                data: updateConversationRequest
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsApi#UpdateConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
