using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateReleaseForFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var createReleaseInput = new CreateReleaseInput(
            releasePipelineKey: "releasePipelineKey_string"
        );

        try
        {
            var response = new ReleasesBetaApi(config).CreateReleaseForFlag(
                projectKey: "projectKey_string",
                flagKey: "flagKey_string",
                createReleaseInput: createReleaseInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ReleasesBetaApi#CreateReleaseForFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
