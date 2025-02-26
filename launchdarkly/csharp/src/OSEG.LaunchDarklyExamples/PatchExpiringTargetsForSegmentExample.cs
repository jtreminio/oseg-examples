using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchExpiringTargetsForSegmentExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var instructions1 = new PatchSegmentExpiringTargetInstruction(
            kind: PatchSegmentExpiringTargetInstruction.KindEnum.UpdateExpiringTarget,
            contextKey: "user@email.com",
            contextKind: "user",
            targetType: PatchSegmentExpiringTargetInstruction.TargetTypeEnum.Included,
            value: 1587582000000,
            varVersion: 0
        );

        var instructions = new List<PatchSegmentExpiringTargetInstruction>
        {
            instructions1,
        };

        var patchSegmentExpiringTargetInputRep = new PatchSegmentExpiringTargetInputRep(
            comment: "optional comment",
            instructions: instructions
        );

        try
        {
            var response = new SegmentsApi(config).PatchExpiringTargetsForSegment(
                projectKey: null,
                environmentKey: null,
                segmentKey: null,
                patchSegmentExpiringTargetInputRep: patchSegmentExpiringTargetInputRep
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SegmentsApi#PatchExpiringTargetsForSegment: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
