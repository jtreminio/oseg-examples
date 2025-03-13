using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchRelayAutoConfigExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var patch1 = new PatchOperation(
            op: "replace",
            path: "/policy/0"
        );

        var patch = new List<PatchOperation>
        {
            patch1,
        };

        var patchWithComment = new PatchWithComment(
            patch: patch
        );

        try
        {
            var response = new RelayProxyConfigurationsApi(config).PatchRelayAutoConfig(
                id: null,
                patchWithComment: patchWithComment
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling RelayProxyConfigurationsApi#PatchRelayAutoConfig: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
