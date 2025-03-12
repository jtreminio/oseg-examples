using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class GetDetailsOfAContactExample
{
    public static void Run()
    {
        var config = new Configuration();

        try
        {
            var response = new ContactsAPIApi(config).GetDetailsOfAContact(
                inboxIdentifier: null,
                contactIdentifier: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContactsAPIApi#GetDetailsOfAContact: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
