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

public class EvaluateContextInstanceExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        try
        {
            var response = new ContextsApi(config).evaluateContextInstance(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                JSON.deserialize("""
                    {
                        "key": "user-key-123abc",
                        "kind": "user",
                        "otherAttribute": "other attribute value"
                    }
                """, Map.class), // requestBody
                null, // limit
                null, // offset
                null, // sort
                null // filter
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContextsApi#evaluateContextInstance");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
