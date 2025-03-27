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

        var payload1 = new ContactFilterRequestPayloadInner(
            attributeKey: "browser_language",
            filterOperator: ContactFilterRequestPayloadInner.FilterOperatorEnum.NotEqualTo,
            queryOperator: ContactFilterRequestPayloadInner.QueryOperatorEnum.AND,
            values: [
                "en",
            ]
        );

        var payload2 = new ContactFilterRequestPayloadInner(
            attributeKey: "status",
            filterOperator: ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
            values: [
                "pending",
            ]
        );

        var payload = new List<ContactFilterRequestPayloadInner>
        {
            payload1,
            payload2,
        };

        var conversationFilterRequest = new ConversationFilterRequest(
            payload: payload
        );

        try
        {
            var response = new ConversationsApi(config).ConversationFilter(
                accountId: 123,
                body: conversationFilterRequest,
                page: 1
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
