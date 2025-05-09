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

public class PatchMetricGroupExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var patchOperation1 = new PatchOperation();
        patchOperation1.op("replace");
        patchOperation1.path("/name");

        var patchOperation = new ArrayList<PatchOperation>(List.of (
            patchOperation1
        ));

        try
        {
            var response = new MetricsBetaApi(config).patchMetricGroup(
                "projectKey_string", // projectKey
                "metricGroupKey_string", // metricGroupKey
                patchOperation
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling MetricsBetaApi#patchMetricGroup");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
