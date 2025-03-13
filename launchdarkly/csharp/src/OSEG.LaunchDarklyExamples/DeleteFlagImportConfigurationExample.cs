using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteFlagImportConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            new FlagImportConfigurationsBetaApi(config).DeleteFlagImportConfiguration(
                projectKey: "projectKey_string",
                integrationKey: "integrationKey_string",
                integrationId: "integrationId_string"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FlagImportConfigurationsBetaApi#DeleteFlagImportConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
