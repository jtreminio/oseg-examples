using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateAnAccountUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        var createAnAccountUserRequest = new CreateAnAccountUserRequest(
            role: "role_string",
            userId: 0
        );

        try
        {
            var response = new AccountUsersApi(config).CreateAnAccountUser(
                accountId: 0,
                data: createAnAccountUserRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountUsersApi#CreateAnAccountUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
