using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateAMessageExample
{
    public static void Run()
    {
        var config = new Configuration();

        var publicMessageUpdatePayload = new PublicMessageUpdatePayload(
        );

        try
        {
            var response = new MessagesAPIApi(config).UpdateAMessage(
                inboxIdentifier: null,
                contactIdentifier: null,
                conversationId: null,
                messageId: null,
                data: publicMessageUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MessagesAPIApi#UpdateAMessage: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
