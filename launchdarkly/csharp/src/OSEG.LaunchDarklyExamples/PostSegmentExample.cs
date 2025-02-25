using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostSegmentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var segmentBody = new SegmentBody(
            name: "Example segment",
            key: "segment-key-123abc",
            description: "Bundle our sample customers together",
            unbounded: false,
            unboundedContextKind: "device",
            tags: [
                "testing",
            ]
        );

        try
        {
            var response = new SegmentsApi(config).PostSegment(
                projectKey: null,
                environmentKey: null,
                segmentBody: segmentBody
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Segments#PostSegment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
