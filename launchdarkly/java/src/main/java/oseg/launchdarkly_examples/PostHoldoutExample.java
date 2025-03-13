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

public class PostHoldoutExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var metrics1 = new MetricInput();
        metrics1.key("metric-key-123abc");
        metrics1.isGroup(true);
        metrics1.primary(true);

        var metrics = new ArrayList<MetricInput>(List.of (
            metrics1
        ));

        var holdoutPostRequest = new HoldoutPostRequest();
        holdoutPostRequest.name("holdout-one-name");
        holdoutPostRequest.key("holdout-key");
        holdoutPostRequest.description("My holdout-one description");
        holdoutPostRequest.randomizationunit("user");
        holdoutPostRequest.holdoutamount("10");
        holdoutPostRequest.primarymetrickey("metric-key-123abc");
        holdoutPostRequest.prerequisiteflagkey("flag-key-123abc");
        holdoutPostRequest.attributes(List.of (
            "country",
            "device",
            "os"
        ));
        holdoutPostRequest.metrics(metrics);

        try
        {
            var response = new HoldoutsBetaApi(config).postHoldout(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                holdoutPostRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling HoldoutsBetaApi#postHoldout");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
