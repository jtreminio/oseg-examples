using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchExpiringUserTargetsForSegmentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var instructions1 = new PatchSegmentInstruction(
            kind: PatchSegmentInstruction.KindEnum.AddExpireUserTargetDate,
            userKey: "sample-user-key",
            targetType: PatchSegmentInstruction.TargetTypeEnum.Included,
            value: 16534692,
            varVersion: 0
        );

        var instructions = new List<PatchSegmentInstruction>
        {
            instructions1,
        };

        var patchSegmentRequest = new PatchSegmentRequest(
            comment: "optional comment",
            instructions: instructions
        );

        try
        {
            var response = new SegmentsApi(config).PatchExpiringUserTargetsForSegment(
                projectKey: "the-project-key",
                environmentKey: "the-environment-key",
                segmentKey: "the-segment-key",
                patchSegmentRequest: patchSegmentRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Segments#PatchExpiringUserTargetsForSegment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
