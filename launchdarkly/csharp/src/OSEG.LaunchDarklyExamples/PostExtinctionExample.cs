using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostExtinctionExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var extinction1 = new Extinction(
            revision: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
            message: "Remove flag for launched feature",
            time: 1706701522000,
            flagKey: "enable-feature",
            projKey: "default"
        );

        var extinction = new List<Extinction>
        {
            extinction1,
        };

        try
        {
            new CodeReferencesApi(config).PostExtinction(
                repo: null,
                branch: null,
                extinction: extinction
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CodeReferencesApi#PostExtinction: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
