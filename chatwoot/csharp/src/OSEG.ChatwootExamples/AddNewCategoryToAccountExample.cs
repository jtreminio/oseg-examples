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
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var categoryCreateUpdatePayload = new CategoryCreateUpdatePayload(
            description: null,
            locale: "en/es",
            name: null,
            slug: null,
            position: null,
            portalId: null,
            accountId: null,
            associatedCategoryId: null,
            parentCategoryId: null
        );

        try
        {
            var response = new HelpCenterApi(config).AddNewCategoryToAccount(
                accountId: null,
                portalId: null,
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
