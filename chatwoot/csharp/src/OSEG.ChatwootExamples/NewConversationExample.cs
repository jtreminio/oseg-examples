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
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};

        var messageTemplateParams = new NewConversationRequestMessageTemplateParams(
            name: "sample_issue_resolution",
            category: "UTILITY",
            language: "en_US"
        );

        var message = new NewConversationRequestMessage(
            content: null,
            templateParams: messageTemplateParams
        );

        var newConversationRequest = new NewConversationRequest(
            inboxId: null,
            sourceId: null,
            contactId: null,
            status: null,
            assigneeId: null,
            teamId: null,
            message: message
        );

        try
        {
            var response = new ConversationsApi(config).NewConversation(
                accountId: null,
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
