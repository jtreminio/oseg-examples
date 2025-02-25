using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchSegmentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var patch1 = new PatchOperation(
            op: "replace",
            path: "/description"
        );

        var patch2 = new PatchOperation(
            op: "add",
            path: "/tags/0"
        );

        var patch = new List<PatchOperation>
        {
            patch1,
            patch2,
        };

        var patchWithComment = new PatchWithComment(
            patch: patch
        );

        try
        {
            var response = new SegmentsApi(config).PatchSegment(
                projectKey: null,
                environmentKey: null,
                segmentKey: null,
                patchWithComment: patchWithComment
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Segments#PatchSegment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
