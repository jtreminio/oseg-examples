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

public class PatchHoldoutExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var holdoutPatchInput = new HoldoutPatchInput();
        holdoutPatchInput.instructions(JSON.deserialize("""
            [
                {
                    "kind": "updateName",
                    "value": "Updated holdout name"
                }
            ]
        """, List.class));
        holdoutPatchInput.comment("Optional comment describing the update");

        try
        {
            var response = new HoldoutsBetaApi(config).patchHoldout(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                "holdoutKey_string", // holdoutKey
                holdoutPatchInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling HoldoutsBetaApi#patchHoldout");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
