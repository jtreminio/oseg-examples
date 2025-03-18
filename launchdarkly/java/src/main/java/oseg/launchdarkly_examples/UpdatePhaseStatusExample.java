package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class UpdatePhaseStatusExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var audiences1ReleaseGuardianConfiguration = new ReleaseGuardianConfigurationInput();
        audiences1ReleaseGuardianConfiguration.monitoringWindowMilliseconds(60000L);
        audiences1ReleaseGuardianConfiguration.rolloutWeight(50);
        audiences1ReleaseGuardianConfiguration.rollbackOnRegression(true);
        audiences1ReleaseGuardianConfiguration.randomizationUnit("user");

        var audiences1 = new ReleaserAudienceConfigInput();
        audiences1.notifyMemberIds(List.of (
            "1234a56b7c89d012345e678f"
        ));
        audiences1.notifyTeamKeys(List.of (
            "example-reviewer-team"
        ));
        audiences1.releaseGuardianConfiguration(audiences1ReleaseGuardianConfiguration);

        var audiences = new ArrayList<ReleaserAudienceConfigInput>(List.of (
            audiences1
        ));

        var updatePhaseStatusInput = new UpdatePhaseStatusInput();
        updatePhaseStatusInput.audiences(audiences);

        try
        {
            var response = new ReleasesBetaApi(config).updatePhaseStatus(
                "projectKey_string", // projectKey
                "flagKey_string", // flagKey
                "phaseId_string", // phaseId
                updatePhaseStatusInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ReleasesBetaApi#updatePhaseStatus");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
