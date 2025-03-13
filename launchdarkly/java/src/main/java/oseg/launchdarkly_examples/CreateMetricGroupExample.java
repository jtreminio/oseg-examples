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

public class CreateMetricGroupExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var metrics1 = new MetricInMetricGroupInput();
        metrics1.key("metric-key-123abc");
        metrics1.nameInGroup("Step 1");

        var metrics = new ArrayList<MetricInMetricGroupInput>(List.of (
            metrics1
        ));

        var metricGroupPost = new MetricGroupPost();
        metricGroupPost.key("metric-group-key-123abc");
        metricGroupPost.name("My metric group");
        metricGroupPost.kind(MetricGroupPost.KindEnum.FUNNEL);
        metricGroupPost.maintainerId("569fdeadbeef1644facecafe");
        metricGroupPost.tags(List.of (
            "ops"
        ));
        metricGroupPost.description("Description of the metric group");
        metricGroupPost.metrics(metrics);

        try
        {
            var response = new MetricsBetaApi(config).createMetricGroup(
                "projectKey_string", // projectKey
                metricGroupPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling MetricsBetaApi#createMetricGroup");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
