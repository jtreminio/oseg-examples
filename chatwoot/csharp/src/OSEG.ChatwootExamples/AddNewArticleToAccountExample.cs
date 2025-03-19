using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class AddNewArticleToAccountExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");

        var articleCreateUpdatePayload = new ArticleCreateUpdatePayload(
            meta: JsonSerializer.Deserialize<Dictionary<string, object>>("""
                {
                    "description": "article description",
                    "tags": [
                        "article_name"
                    ],
                    "title": "article title"
                }
            """)
        );

        try
        {
            var response = new HelpCenterApi(config).AddNewArticleToAccount(
                accountId: 0,
                portalId: 0,
                data: articleCreateUpdatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling HelpCenterApi#AddNewArticleToAccount: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
