using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class GetSubscriptionsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new IntegrationAuditLogSubscriptionsApi(config).GetSubscriptions(
                integrationKey: "integrationKey_string"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationAuditLogSubscriptionsApi#GetSubscriptions: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
