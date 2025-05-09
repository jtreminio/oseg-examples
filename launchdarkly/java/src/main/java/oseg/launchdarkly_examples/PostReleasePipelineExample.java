package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PostReleasePipelineExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var phases1Audiences1ConfigurationReleaseGuardianConfiguration = new ReleaseGuardianConfiguration();
        phases1Audiences1ConfigurationReleaseGuardianConfiguration.monitoringWindowMilliseconds(60000L);
        phases1Audiences1ConfigurationReleaseGuardianConfiguration.rolloutWeight(50);
        phases1Audiences1ConfigurationReleaseGuardianConfiguration.rollbackOnRegression(true);
        phases1Audiences1ConfigurationReleaseGuardianConfiguration.randomizationUnit("user");

        var phases1Audiences1Configuration = new AudienceConfiguration();
        phases1Audiences1Configuration.releaseStrategy("the-release-strategy");
        phases1Audiences1Configuration.requireApproval(true);
        phases1Audiences1Configuration.notifyMemberIds(List.of (
            "1234a56b7c89d012345e678f"
        ));
        phases1Audiences1Configuration.notifyTeamKeys(List.of (
            "example-reviewer-team"
        ));
        phases1Audiences1Configuration.releaseGuardianConfiguration(phases1Audiences1ConfigurationReleaseGuardianConfiguration);

        var phases1Audiences1 = new AudiencePost();
        phases1Audiences1.environmentKey("the-environment-key");
        phases1Audiences1.name("Some name");
        phases1Audiences1.segmentKeys(List.of ());
        phases1Audiences1._configuration(phases1Audiences1Configuration);

        var phases1Audiences = new ArrayList<AudiencePost>(List.of (
            phases1Audiences1
        ));

        var phases1 = new CreatePhaseInput();
        phases1.name("Phase 1 - Testing");
        phases1.audiences(phases1Audiences);

        var phases = new ArrayList<CreatePhaseInput>(List.of (
            phases1
        ));

        var createReleasePipelineInput = new CreateReleasePipelineInput();
        createReleasePipelineInput.key("standard-pipeline");
        createReleasePipelineInput.name("Standard Pipeline");
        createReleasePipelineInput.description("Standard pipeline to roll out to production");
        createReleasePipelineInput.isProjectDefault(false);
        createReleasePipelineInput.isLegacy(false);
        createReleasePipelineInput.tags(List.of (
            "example-tag"
        ));
        createReleasePipelineInput.phases(phases);

        try
        {
            var response = new ReleasePipelinesBetaApi(config).postReleasePipeline(
                "the-project-key", // projectKey
                createReleasePipelineInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ReleasePipelinesBetaApi#postReleasePipeline");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
