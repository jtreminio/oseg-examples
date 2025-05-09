using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchIntegrationDeliveryConfigurationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var patchOperation1 = new PatchOperation(
            op: "replace",
            path: "/on"
        );

        var patchOperation = new List<PatchOperation>
        {
            patchOperation1,
        };

        try
        {
            var response = new IntegrationDeliveryConfigurationsBetaApi(config).PatchIntegrationDeliveryConfiguration(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                integrationKey: "integrationKey_string",
                id: "id_string",
                patchOperation: patchOperation
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IntegrationDeliveryConfigurationsBetaApi#PatchIntegrationDeliveryConfiguration: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
