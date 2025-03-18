using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteIntegrationDeliveryConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            new IntegrationDeliveryConfigurationsBetaApi(config).DeleteIntegrationDeliveryConfiguration(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                integrationKey: "integrationKey_string",
                id: "id_string"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationDeliveryConfigurationsBetaApi#DeleteIntegrationDeliveryConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
