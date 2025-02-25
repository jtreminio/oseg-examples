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

public class GetLeadTimeChartExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        try
        {
            var response = new InsightsChartsBetaApi(config).getLeadTimeChart(
                null, // projectKey
                null, // environmentKey
                null, // applicationKey
                null, // from
                null, // to
                null, // bucketType
                null, // bucketMs
                null, // groupBy
                null // expand
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling InsightsChartsBeta#getLeadTimeChart");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
