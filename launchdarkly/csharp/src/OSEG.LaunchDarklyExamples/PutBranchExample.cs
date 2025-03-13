using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutBranchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var references1Hunks1 = new HunkRep(
            startingLineNumber: 45,
            lines: "var enableFeature = 'enable-feature';",
            projKey: "default",
            flagKey: "enable-feature",
            aliases: [
                "enableFeature",
                "EnableFeature",
            ]
        );

        var references1Hunks = new List<HunkRep>
        {
            references1Hunks1,
        };

        var references1 = new ReferenceRep(
            path: "/main/index.js",
            hint: "javascript",
            hunks: references1Hunks
        );

        var references = new List<ReferenceRep>
        {
            references1,
        };

        var putBranch = new PutBranch(
            name: "main",
            head: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
            syncTime: 1706701522000,
            updateSequenceId: 25,
            commitTime: 1706701522000,
            references: references
        );

        try
        {
            new CodeReferencesApi(config).PutBranch(
                repo: null,
                branch: null,
                putBranch: putBranch
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling CodeReferencesApi#PutBranch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
