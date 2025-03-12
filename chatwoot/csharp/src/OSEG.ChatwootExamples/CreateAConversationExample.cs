using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateAConversationExample
{
    public static void Run()
    {
        var config = new Configuration();

        var publicConversationCreatePayload = new PublicConversationCreatePayload(
        );

        try
        {
            var response = new ConversationsAPIApi(config).CreateAConversation(
                inboxIdentifier: null,
                contactIdentifier: null,
                data: publicConversationCreatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsAPIApi#CreateAConversation: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
