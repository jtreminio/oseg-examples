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

public class CreateSubscriptionExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var statements1 = new StatementPost();
        statements1.effect(StatementPost.EffectEnum.ALLOW);
        statements1.resources(List.of (
            "proj/*:env/*:flag/*;testing-tag"
        ));
        statements1.actions(List.of (
            "*"
        ));

        var statements = new ArrayList<StatementPost>(List.of (
            statements1
        ));

        var subscriptionPost = new SubscriptionPost();
        subscriptionPost.name("Example audit log subscription.");
        subscriptionPost.config(JSON.deserialize("""
            {
                "optional": "an optional property",
                "required": "the required property",
                "url": "https://example.com"
            }
        """, Map.class));
        subscriptionPost.on(false);
        subscriptionPost.tags(List.of (
            "testing-tag"
        ));
        subscriptionPost.statements(statements);

        try
        {
            var response = new IntegrationAuditLogSubscriptionsApi(config).createSubscription(
                "integrationKey_string", // integrationKey
                subscriptionPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling IntegrationAuditLogSubscriptionsApi#createSubscription");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
