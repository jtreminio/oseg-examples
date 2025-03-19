using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewCategoryToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var categoryCreateUpdatePayload = new CategoryCreateUpdatePayload(
            locale: "en/es"
        );

        try
        {
            var response = new HelpCenterApi(config).AddNewCategoryToAccount(
                accountId: 0,
                portalId: 0,
                data: categoryCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HelpCenterApi#AddNewCategoryToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
