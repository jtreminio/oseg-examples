using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class CreateAnIntegrationHookExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");
        // config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        var integrationsHookCreatePayload = new IntegrationsHookCreatePayload(
        );

        try
        {
            var response = new IntegrationsApi(config).CreateAnIntegrationHook(
                accountId: 0,
                data: integrationsHookCreatePayload
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationsApi#CreateAnIntegrationHook: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
