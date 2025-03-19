using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteAnAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        try
        {
            new AccountsApi(config).DeleteAnAccount(
                accountId: 0
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountsApi#DeleteAnAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
