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

public class CreateBigSegmentStoreIntegrationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var integrationDeliveryConfigurationPost = new IntegrationDeliveryConfigurationPost();
        integrationDeliveryConfigurationPost.config(JSON.deserialize("""
            {
                "optional": "example value for optional formVariables property for sample-integration",
                "required": "example value for required formVariables property for sample-integration"
            }
        """, Map.class));
        integrationDeliveryConfigurationPost.on(false);
        integrationDeliveryConfigurationPost.name("Example persistent store integration");
        integrationDeliveryConfigurationPost.tags(List.of (
            "example-tag"
        ));

        try
        {
            var response = new PersistentStoreIntegrationsBetaApi(config).createBigSegmentStoreIntegration(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                "integrationKey_string", // integrationKey
                integrationDeliveryConfigurationPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersistentStoreIntegrationsBetaApi#createBigSegmentStoreIntegration");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
