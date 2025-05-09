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

public class PatchAIConfigVariationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var messages1 = new Message();
        messages1.content("content");
        messages1.role("role");

        var messages2 = new Message();
        messages2.content("content");
        messages2.role("role");

        var messages = new ArrayList<Message>(List.of (
            messages1,
            messages2
        ));

        var aiConfigVariationPatch = new AIConfigVariationPatch();
        aiConfigVariationPatch.modelConfigKey("modelConfigKey");
        aiConfigVariationPatch.name("name");
        aiConfigVariationPatch.published(true);
        aiConfigVariationPatch.model(Map.of ());
        aiConfigVariationPatch.messages(messages);

        try
        {
            var response = new AiConfigsBetaApi(config).patchAIConfigVariation(
                "beta", // ldAPIVersion
                "projectKey_string", // projectKey
                "configKey_string", // configKey
                "variationKey_string", // variationKey
                aiConfigVariationPatch
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AiConfigsBetaApi#patchAIConfigVariation");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
