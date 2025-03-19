using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateAContactExample
{
    public static void Run()
    {
        var config = new Configuration();

        var publicContactCreateUpdatePayload = new PublicContactCreateUpdatePayload(
        );

        try
        {
            var response = new ContactsAPIApi(config).UpdateAContact(
                inboxIdentifier: "inbox_identifier_string",
                contactIdentifier: "contact_identifier_string",
                data: publicContactCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContactsAPIApi#UpdateAContact: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
