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

public class PatchExpiringUserTargetsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var patchFlagsRequest = new PatchFlagsRequest();
        patchFlagsRequest.instructions(JSON.deserialize("""
            [
                {
                    "kind": "addExpireUserTargetDate",
                    "userKey": "sandy",
                    "value": 1686412800000,
                    "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
                }
            ]
        """, List.class));
        patchFlagsRequest.comment("optional comment");

        try
        {
            var response = new FeatureFlagsApi(config).patchExpiringUserTargets(
                null, // projectKey
                null, // environmentKey
                null, // featureFlagKey
                patchFlagsRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FeatureFlagsApi#patchExpiringUserTargets");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
