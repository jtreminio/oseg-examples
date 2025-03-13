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

public class GetFlagEventsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        try
        {
            var response = new InsightsFlagEventsBetaApi(config).getFlagEvents(
                null, // projectKey
                null, // environmentKey
                null, // applicationKey
                null, // query
                null, // impactSize
                null, // hasExperiments
                null, // global
                null, // expand
                null, // limit
                null, // from
                null, // to
                null, // after
                null // before
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling InsightsFlagEventsBetaApi#getFlagEvents");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
