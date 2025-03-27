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
        );

        try
        {
            var response = new MessagesAPIApi(config).CreateAMessage(
                inboxIdentifier: "inbox_identifier_string",
                contactIdentifier: "contact_identifier_string",
                conversationId: 0,
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
