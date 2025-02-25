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

public class CreateTriggerWorkflowExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var triggerPost = new TriggerPost();
        triggerPost.integrationKey("generic-trigger");
        triggerPost.comment("example comment");
        triggerPost.instructions(JSON.deserialize("""
            [
                {
                    "kind": "turnFlagOn"
                }
            ]
        """, List.class));

        try
        {
            var response = new FlagTriggersApi(config).createTriggerWorkflow(
                null, // projectKey
                null, // environmentKey
                null, // featureFlagKey
                triggerPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FlagTriggers#createTriggerWorkflow");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
