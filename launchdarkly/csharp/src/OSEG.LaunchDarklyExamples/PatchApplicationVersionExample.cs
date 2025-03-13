using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchApplicationVersionExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var patchOperation1 = new PatchOperation(
            op: "replace",
            path: "/supported"
        );

        var patchOperation = new List<PatchOperation>
        {
            patchOperation1,
        };

        try
        {
            var response = new ApplicationsBetaApi(config).PatchApplicationVersion(
                applicationKey: "applicationKey_string",
                versionKey: "versionKey_string",
                patchOperation: patchOperation
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApplicationsBetaApi#PatchApplicationVersion: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
