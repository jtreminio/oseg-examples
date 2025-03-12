using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewPortalToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var portalCreateUpdatePayload = new PortalCreateUpdatePayload(
            archived: null,
            color: "add color HEX string, \"#fffff\"",
            customDomain: "https://chatwoot.help/.",
            headerText: "Handbook",
            homepageLink: "https://www.chatwoot.com/",
            name: null,
            slug: null,
            pageTitle: null,
            accountId: null
        );

        try
        {
            var response = new HelpCenterApi(config).AddNewPortalToAccount(
                accountId: null,
                data: portalCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HelpCenterApi#AddNewPortalToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
