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

public class PostRelayAutoConfigExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var policy1 = new Statement();
        policy1.effect(Statement.EffectEnum.ALLOW);
        policy1.resources(List.of (
            "proj/*:env/*"
        ));
        policy1.actions(List.of (
            "*"
        ));

        var policy = new ArrayList<Statement>(List.of (
            policy1
        ));

        var relayAutoConfigPost = new RelayAutoConfigPost();
        relayAutoConfigPost.name("Sample Relay Proxy config for all proj and env");
        relayAutoConfigPost.policy(policy);

        try
        {
            var response = new RelayProxyConfigurationsApi(config).postRelayAutoConfig(
                relayAutoConfigPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling RelayProxyConfigurationsApi#postRelayAutoConfig");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
