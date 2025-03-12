using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateAMessageExample
{
    public static void Run()
    {
        var config = new Configuration();

        var publicMessageCreatePayload = new PublicMessageCreatePayload(
            content: null,
            echoId: null
        );

        try
        {
            var response = new MessagesAPIApi(config).CreateAMessage(
                inboxIdentifier: null,
                contactIdentifier: null,
                conversationId: null,
                data: publicMessageCreatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling MessagesAPIApi#CreateAMessage: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
