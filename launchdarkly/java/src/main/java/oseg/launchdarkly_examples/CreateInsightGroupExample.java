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

public class CreateInsightGroupExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var postInsightGroupParams = new PostInsightGroupParams();
        postInsightGroupParams.name("Production - All Apps");
        postInsightGroupParams.key("default-production-all-apps");
        postInsightGroupParams.projectKey("default");
        postInsightGroupParams.environmentKey("production");
        postInsightGroupParams.applicationKeys(List.of (
            "billing-service",
            "inventory-service"
        ));

        try
        {
            var response = new InsightsScoresBetaApi(config).createInsightGroup(
                postInsightGroupParams
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling InsightsScoresBetaApi#createInsightGroup");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
