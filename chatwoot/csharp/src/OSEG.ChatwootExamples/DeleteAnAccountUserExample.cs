using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class DeleteAnAccountUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["platformAppApiKey"] = "PLATFORM_APP_API_KEY"};

        var deleteAnAccountUserRequest = new DeleteAnAccountUserRequest(
            userId: null
        );

        try
        {
            new AccountUsersApi(config).DeleteAnAccountUser(
                accountId: null,
                data: deleteAnAccountUserRequest
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountUsersApi#DeleteAnAccountUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
