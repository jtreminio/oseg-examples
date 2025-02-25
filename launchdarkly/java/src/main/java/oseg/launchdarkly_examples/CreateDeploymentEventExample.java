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

public class CreateDeploymentEventExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var postDeploymentEventInput = new PostDeploymentEventInput();
        postDeploymentEventInput.projectKey("default");
        postDeploymentEventInput.environmentKey("production");
        postDeploymentEventInput.applicationKey("billing-service");
        postDeploymentEventInput.version("a90a8a2");
        postDeploymentEventInput.eventType(PostDeploymentEventInput.EventTypeEnum.STARTED);
        postDeploymentEventInput.applicationName("Billing Service");
        postDeploymentEventInput.applicationKind(PostDeploymentEventInput.ApplicationKindEnum.SERVER);
        postDeploymentEventInput.versionName("v1.0.0");
        postDeploymentEventInput.eventTime(1706701522000L);
        postDeploymentEventInput.eventMetadata(JSON.deserialize("""
            {
                "buildSystemVersion": "v1.2.3"
            }
        """, Map.class));
        postDeploymentEventInput.deploymentMetadata(JSON.deserialize("""
            {
                "buildNumber": "1234"
            }
        """, Map.class));

        try
        {
            new InsightsDeploymentsBetaApi(config).createDeploymentEvent(
                postDeploymentEventInput
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling InsightsDeploymentsBeta#createDeploymentEvent");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
