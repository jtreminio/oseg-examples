using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class UpdatePhaseStatusExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var audiences1ReleaseGuardianConfiguration = new ReleaseGuardianConfigurationInput(
            monitoringWindowMilliseconds: 60000,
            rolloutWeight: 50,
            rollbackOnRegression: true,
            randomizationUnit: "user"
        );

        var audiences1 = new ReleaserAudienceConfigInput(
            notifyMemberIds: [
                "1234a56b7c89d012345e678f",
            ],
            notifyTeamKeys: [
                "example-reviewer-team",
            ],
            releaseGuardianConfiguration: audiences1ReleaseGuardianConfiguration
        );

        var audiences = new List<ReleaserAudienceConfigInput>
        {
            audiences1,
        };

        var updatePhaseStatusInput = new UpdatePhaseStatusInput(
            audiences: audiences
        );

        try
        {
            var response = new ReleasesBetaApi(config).UpdatePhaseStatus(
                projectKey: "projectKey_string",
                flagKey: "flagKey_string",
                phaseId: "phaseId_string",
                updatePhaseStatusInput: updatePhaseStatusInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ReleasesBetaApi#UpdatePhaseStatus: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
