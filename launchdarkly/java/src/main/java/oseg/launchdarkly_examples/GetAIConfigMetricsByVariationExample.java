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

public class GetAIConfigMetricsByVariationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        try
        {
            var response = new AiConfigsBetaApi(config).getAIConfigMetricsByVariation(
                null, // ldAPIVersion
                null, // projectKey
                null, // configKey
                123, // from
                456, // to
                null // env
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AiConfigsBetaApi#getAIConfigMetricsByVariation");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
