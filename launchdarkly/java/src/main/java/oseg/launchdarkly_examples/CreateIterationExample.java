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

public class CreateIterationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var treatments1Parameters1 = new TreatmentParameterInput();
        treatments1Parameters1.flagKey("example-flag-for-experiment");
        treatments1Parameters1.variationId("e432f62b-55f6-49dd-a02f-eb24acf39d05");

        var treatments1Parameters = new ArrayList<TreatmentParameterInput>(List.of (
            treatments1Parameters1
        ));

        var metrics1 = new MetricInput();
        metrics1.key("metric-key-123abc");
        metrics1.isGroup(true);
        metrics1.primary(true);

        var metrics = new ArrayList<MetricInput>(List.of (
            metrics1
        ));

        var treatments1 = new TreatmentInput();
        treatments1.name("Treatment 1");
        treatments1.baseline(true);
        treatments1.allocationPercent("10");
        treatments1.parameters(treatments1Parameters);

        var treatments = new ArrayList<TreatmentInput>(List.of (
            treatments1
        ));

        var iterationInput = new IterationInput();
        iterationInput.hypothesis("Example hypothesis, the new button placement will increase conversion");
        iterationInput.flags(Map.of ());
        iterationInput.canReshuffleTraffic(true);
        iterationInput.primarySingleMetricKey("metric-key-123abc");
        iterationInput.primaryFunnelKey("metric-group-key-123abc");
        iterationInput.randomizationUnit("user");
        iterationInput.attributes(List.of (
            "country",
            "device",
            "os"
        ));
        iterationInput.metrics(metrics);
        iterationInput.treatments(treatments);

        try
        {
            var response = new ExperimentsApi(config).createIteration(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                "experimentKey_string", // experimentKey
                iterationInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ExperimentsApi#createIteration");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
