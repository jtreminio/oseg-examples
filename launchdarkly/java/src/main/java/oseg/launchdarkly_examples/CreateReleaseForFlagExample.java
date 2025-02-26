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

public class CreateReleaseForFlagExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var createReleaseInput = new CreateReleaseInput();
        createReleaseInput.releasePipelineKey(null);
        createReleaseInput.releaseVariationId(null);

        try
        {
            var response = new ReleasesBetaApi(config).createReleaseForFlag(
                null, // projectKey
                null, // flagKey
                createReleaseInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ReleasesBetaApi#createReleaseForFlag");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
