using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostFeatureFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var clientSideAvailability = new ClientSideAvailabilityPost(
            usingEnvironmentId: true,
            usingMobileKey: true
        );

        var featureFlagBody = new FeatureFlagBody(
            name: "My Flag",
            key: "flag-key-123abc",
            clientSideAvailability: clientSideAvailability
        );

        try
        {
            var response = new FeatureFlagsApi(config).PostFeatureFlag(
                projectKey: "projectKey_string",
                featureFlagBody: featureFlagBody
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling FeatureFlagsApi#PostFeatureFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
