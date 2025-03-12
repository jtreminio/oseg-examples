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
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};

        var templateParams = new ConversationMessageCreateTemplateParams(
            name: "sample_issue_resolution",
            category: "UTILITY",
            language: "en_US"
        );

        var conversationMessageCreate = new ConversationMessageCreate(
            content: null,
            messageType: null,
            varPrivate: null,
            contentType: ConversationMessageCreate.ContentTypeEnum.Cards,
            templateParams: templateParams
        );

        try
        {
            var response = new MessagesApi(config).CreateANewMessageInAConversation(
                accountId: null,
                conversationId: null,
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
