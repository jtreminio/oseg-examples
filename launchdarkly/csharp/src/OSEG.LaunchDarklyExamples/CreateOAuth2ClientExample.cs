using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateOAuth2ClientExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var oauthClientPost = new OauthClientPost(
            name: null,
            redirectUri: null,
            description: null
        );

        try
        {
            var response = new OAuth2ClientsApi(config).CreateOAuth2Client(
                oauthClientPost: oauthClientPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling OAuth2Clients#CreateOAuth2Client: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
