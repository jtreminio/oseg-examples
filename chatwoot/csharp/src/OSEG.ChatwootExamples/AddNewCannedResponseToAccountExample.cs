using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewCannedResponseToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var cannedResponseCreateUpdatePayload = new CannedResponseCreateUpdatePayload(
        );

        try
        {
            var response = new CannedResponsesApi(config).AddNewCannedResponseToAccount(
                accountId: 0,
                data: cannedResponseCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CannedResponsesApi#AddNewCannedResponseToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
