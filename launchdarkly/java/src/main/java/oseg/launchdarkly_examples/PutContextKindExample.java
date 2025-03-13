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

public class PutContextKindExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var upsertContextKindPayload = new UpsertContextKindPayload();
        upsertContextKindPayload.name("organization");
        upsertContextKindPayload.description("An example context kind for organizations");
        upsertContextKindPayload.hideInTargeting(false);
        upsertContextKindPayload.archived(false);
        upsertContextKindPayload.version(1);

        try
        {
            var response = new ContextsApi(config).putContextKind(
                "projectKey_string", // projectKey
                "key_string", // key
                upsertContextKindPayload
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContextsApi#putContextKind");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
