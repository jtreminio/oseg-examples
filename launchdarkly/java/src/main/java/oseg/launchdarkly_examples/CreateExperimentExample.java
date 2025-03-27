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

public class CreateExperimentExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var iterationTreatments1Parameters1 = new TreatmentParameterInput();
        iterationTreatments1Parameters1.flagKey("example-flag-for-experiment");
        iterationTreatments1Parameters1.variationId("e432f62b-55f6-49dd-a02f-eb24acf39d05");

        var iterationTreatments1Parameters = new ArrayList<TreatmentParameterInput>(List.of (
            iterationTreatments1Parameters1
        ));

        var iterationMetrics1 = new MetricInput();
        iterationMetrics1.key("metric-key-123abc");
        iterationMetrics1.isGroup(true);
        iterationMetrics1.primary(true);

        var iterationMetrics = new ArrayList<MetricInput>(List.of (
            iterationMetrics1
        ));

        var iterationTreatments1 = new TreatmentInput();
        iterationTreatments1.name("Treatment 1");
        iterationTreatments1.baseline(true);
        iterationTreatments1.allocationPercent("10");
        iterationTreatments1.parameters(iterationTreatments1Parameters);

        var iterationTreatments = new ArrayList<TreatmentInput>(List.of (
            iterationTreatments1
        ));

        var iteration = new IterationInput();
        iteration.hypothesis("Example hypothesis, the new button placement will increase conversion");
        iteration.flags(Map.of ());
        iteration.canReshuffleTraffic(true);
        iteration.primarySingleMetricKey("metric-key-123abc");
        iteration.primaryFunnelKey("metric-group-key-123abc");
        iteration.randomizationUnit("user");
        iteration.attributes(List.of (
            "country",
            "device",
            "os"
        ));
        iteration.metrics(iterationMetrics);
        iteration.treatments(iterationTreatments);

        var experimentPost = new ExperimentPost();
        experimentPost.name("Example experiment");
        experimentPost.key("experiment-key-123abc");
        experimentPost.description("An example experiment, used in testing");
        experimentPost.maintainerId("12ab3c45de678910fgh12345");
        experimentPost.holdoutId("f3b74309-d581-44e1-8a2b-bb2933b4fe40");
        experimentPost.iteration(iteration);

        try
        {
            var response = new ExperimentsApi(config).createExperiment(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                experimentPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ExperimentsApi#createExperiment");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
