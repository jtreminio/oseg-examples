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

public class PutFlagDefaultsByProjectExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var booleanDefaults = new BooleanFlagDefaults();
        booleanDefaults.trueDisplayName("True");
        booleanDefaults.falseDisplayName("False");
        booleanDefaults.trueDescription("serve true");
        booleanDefaults.falseDescription("serve false");
        booleanDefaults.onVariation(0);
        booleanDefaults.offVariation(1);

        var defaultClientSideAvailability = new DefaultClientSideAvailability();
        defaultClientSideAvailability.usingMobileKey(true);
        defaultClientSideAvailability.usingEnvironmentId(true);

        var upsertFlagDefaultsPayload = new UpsertFlagDefaultsPayload();
        upsertFlagDefaultsPayload.temporary(true);
        upsertFlagDefaultsPayload.tags(List.of (
            "tag-1",
            "tag-2"
        ));
        upsertFlagDefaultsPayload.booleanDefaults(booleanDefaults);
        upsertFlagDefaultsPayload.defaultClientSideAvailability(defaultClientSideAvailability);

        try
        {
            var response = new ProjectsApi(config).putFlagDefaultsByProject(
                "projectKey_string", // projectKey
                upsertFlagDefaultsPayload
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ProjectsApi#putFlagDefaultsByProject");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
