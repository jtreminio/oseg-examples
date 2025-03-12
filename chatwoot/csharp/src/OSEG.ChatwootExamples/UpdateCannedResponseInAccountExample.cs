using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateCannedResponseInAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var cannedResponseCreateUpdatePayload = new CannedResponseCreateUpdatePayload(
            content: null,
            shortCode: null
        );

        try
        {
            var response = new CannedResponseApi(config).UpdateCannedResponseInAccount(
                accountId: null,
                id: null,
                data: cannedResponseCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CannedResponseApi#UpdateCannedResponseInAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
