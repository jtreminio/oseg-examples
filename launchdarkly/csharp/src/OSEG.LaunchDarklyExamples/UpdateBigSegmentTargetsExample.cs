using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class UpdateBigSegmentTargetsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var included = new SegmentUserList(
            add: [
            ],
            remove: [
            ]
        );

        var excluded = new SegmentUserList(
            add: [
            ],
            remove: [
            ]
        );

        var segmentUserState = new SegmentUserState(
            included: included,
            excluded: excluded
        );

        try
        {
            new SegmentsApi(config).UpdateBigSegmentTargets(
                projectKey: null,
                environmentKey: null,
                segmentKey: null,
                segmentUserState: segmentUserState
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SegmentsApi#UpdateBigSegmentTargets: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
