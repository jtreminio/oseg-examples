using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class UpdateNewPortalToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var portalCreateUpdatePayload = new PortalCreateUpdatePayload(
            color: "add color HEX string, \"#fffff\"",
            customDomain: "https://chatwoot.help/.",
            headerText: "Handbook",
            homepageLink: "https://www.chatwoot.com/",
            config: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "allowed_locales": [
                        "en",
                        "es"
                    ],
                    "default_locale": "en"
                }
            """)
        );

        try
        {
            var response = new HelpCenterApi(config).UpdateNewPortalToAccount(
                accountId: 0,
                data: portalCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HelpCenterApi#UpdateNewPortalToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
