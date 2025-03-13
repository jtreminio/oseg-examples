using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteReleasePipelineExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            new ReleasePipelinesBetaApi(config).DeleteReleasePipeline(
                projectKey: "projectKey_string",
                pipelineKey: "pipelineKey_string"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ReleasePipelinesBetaApi#DeleteReleasePipeline: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
