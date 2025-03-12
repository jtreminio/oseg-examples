using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateAContactExample
{
    public static void Run()
    {
        var config = new Configuration();

        var publicContactCreateUpdatePayload = new PublicContactCreateUpdatePayload(
            identifier: null,
            identifierHash: null,
            email: null,
            name: null,
            phoneNumber: null,
            avatarUrl: null
        );

        try
        {
            var response = new ContactsAPIApi(config).CreateAContact(
                inboxIdentifier: null,
                data: publicContactCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContactsAPIApi#CreateAContact: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
