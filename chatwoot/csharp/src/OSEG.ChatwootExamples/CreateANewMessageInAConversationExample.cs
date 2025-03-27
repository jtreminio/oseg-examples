using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateANewMessageInAConversationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var templateParams = new NewConversationRequestMessageTemplateParams(
            name: "sample_issue_resolution",
            category: "UTILITY",
            language: "en_US",
            processedParams: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "1": "Chatwoot"
                }
            """)
        );

        var conversationMessageCreate = new ConversationMessageCreate(
            content: "content_string",
            contentType: ConversationMessageCreate.ContentTypeEnum.Cards,
            templateParams: templateParams
        );

        try
        {
            var response = new MessagesApi(config).CreateANewMessageInAConversation(
                accountId: 0,
                conversationId: 0,
                data: conversationMessageCreate
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MessagesApi#CreateANewMessageInAConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
