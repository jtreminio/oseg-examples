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

public class CreateFlagLinkExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var flagLinkPost = new FlagLinkPost();
        flagLinkPost.key("flag-link-key-123abc");
        flagLinkPost.deepLink("https://example.com/archives/123123123");
        flagLinkPost.title("Example link title");
        flagLinkPost.description("Example link description");

        try
        {
            var response = new FlagLinksBetaApi(config).createFlagLink(
                "projectKey_string", // projectKey
                "featureFlagKey_string", // featureFlagKey
                flagLinkPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FlagLinksBetaApi#createFlagLink");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
