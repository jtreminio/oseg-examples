using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostReleasePipelineExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var phases1Audiences1ConfigurationReleaseGuardianConfiguration = new ReleaseGuardianConfiguration(
            monitoringWindowMilliseconds: 60000,
            rolloutWeight: 50,
            rollbackOnRegression: true,
            randomizationUnit: "user"
        );

        var phases1Audiences1Configuration = new AudienceConfiguration(
            releaseStrategy: "the-release-strategy",
            requireApproval: true,
            notifyMemberIds: [
                "1234a56b7c89d012345e678f",
            ],
            notifyTeamKeys: [
                "example-reviewer-team",
            ],
            releaseGuardianConfiguration: phases1Audiences1ConfigurationReleaseGuardianConfiguration
        );

        var phases1Audiences1 = new AudiencePost(
            environmentKey: "the-environment-key",
            name: "Some name",
            segmentKeys: [
            ],
            varConfiguration: phases1Audiences1Configuration
        );

        var phases1Audiences = new List<AudiencePost>
        {
            phases1Audiences1,
        };

        var phases1 = new CreatePhaseInput(
            name: "Phase 1 - Testing",
            audiences: phases1Audiences
        );

        var phases = new List<CreatePhaseInput>
        {
            phases1,
        };

        var createReleasePipelineInput = new CreateReleasePipelineInput(
            key: "standard-pipeline",
            name: "Standard Pipeline",
            description: "Standard pipeline to roll out to production",
            isProjectDefault: false,
            isLegacy: false,
            tags: [
                "example-tag",
            ],
            phases: phases
        );

        try
        {
            var response = new ReleasePipelinesBetaApi(config).PostReleasePipeline(
                projectKey: "the-project-key",
                createReleasePipelineInput: createReleasePipelineInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ReleasePipelinesBetaApi#PostReleasePipeline: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
