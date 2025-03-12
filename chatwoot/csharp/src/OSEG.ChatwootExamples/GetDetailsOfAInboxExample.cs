using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class GetDetailsOfAInboxExample
{
    public static void Run()
    {
        var config = new Configuration();

        try
        {
            var response = new InboxAPIApi(config).GetDetailsOfAInbox(
                inboxIdentifier: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling InboxAPIApi#GetDetailsOfAInbox: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
