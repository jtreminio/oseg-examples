using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewCustomAttributeToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var customAttributeCreateUpdatePayload = new CustomAttributeCreateUpdatePayload(
            attributeValues: [
            ]
        );

        try
        {
            var response = new CustomAttributesApi(config).AddNewCustomAttributeToAccount(
                accountId: 0,
                data: customAttributeCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CustomAttributesApi#AddNewCustomAttributeToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
