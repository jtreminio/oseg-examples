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
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};

        var articleCreateUpdatePayload = new ArticleCreateUpdatePayload(
            content: null,
            position: null,
            status: null,
            title: null,
            slug: null,
            views: null,
            portalId: null,
            accountId: null,
            authorId: null,
            categoryId: null,
            folderId: null,
            associatedArticleId: null
        );

        try
        {
            var response = new HelpCenterApi(config).AddNewArticleToAccount(
                accountId: null,
                portalId: null,
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
