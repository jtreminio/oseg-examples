using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteCustomAttributeFromAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        try
        {
            new CustomAttributesApi(config).DeleteCustomAttributeFromAccount(
                accountId: null,
                id: null
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CustomAttributesApi#DeleteCustomAttributeFromAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
