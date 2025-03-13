using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostDestinationExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var destinationPost = new DestinationPost(
            kind: DestinationPost.KindEnum.GooglePubsub
        );

        try
        {
            var response = new DataExportDestinationsApi(config).PostDestination(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                destinationPost: destinationPost
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling DataExportDestinationsApi#PostDestination: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
