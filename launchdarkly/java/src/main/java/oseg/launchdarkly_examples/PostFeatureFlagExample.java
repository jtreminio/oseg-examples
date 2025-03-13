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

public class PostFeatureFlagExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var clientSideAvailability = new ClientSideAvailabilityPost();
        clientSideAvailability.usingEnvironmentId(true);
        clientSideAvailability.usingMobileKey(true);

        var featureFlagBody = new FeatureFlagBody();
        featureFlagBody.name("My Flag");
        featureFlagBody.key("flag-key-123abc");
        featureFlagBody.clientSideAvailability(clientSideAvailability);

        try
        {
            var response = new FeatureFlagsApi(config).postFeatureFlag(
                null, // projectKey
                featureFlagBody,
                null // clone
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FeatureFlagsApi#postFeatureFlag");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
