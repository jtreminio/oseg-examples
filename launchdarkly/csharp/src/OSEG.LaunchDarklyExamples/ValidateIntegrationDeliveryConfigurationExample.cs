using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class ValidateIntegrationDeliveryConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            var response = new IntegrationDeliveryConfigurationsBetaApi(config).ValidateIntegrationDeliveryConfiguration(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                integrationKey: "integrationKey_string",
                id: "id_string"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationDeliveryConfigurationsBetaApi#ValidateIntegrationDeliveryConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
