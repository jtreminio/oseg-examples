using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchRepositoryExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var patchOperation1 = new PatchOperation(
            op: "replace",
            path: "/defaultBranch"
        );

        var patchOperation = new List<PatchOperation>
        {
            patchOperation1,
        };

        try
        {
            var response = new CodeReferencesApi(config).PatchRepository(
                repo: "repo_string",
                patchOperation: patchOperation
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CodeReferencesApi#PatchRepository: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
