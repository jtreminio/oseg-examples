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

public class SearchContextInstancesExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var contextInstanceSearch = new ContextInstanceSearch();
        contextInstanceSearch.filter("{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}");
        contextInstanceSearch.sort("-ts");
        contextInstanceSearch.limit(10);
        contextInstanceSearch.continuationToken("QAGFKH1313KUGI2351");

        try
        {
            var response = new ContextsApi(config).searchContextInstances(
                null, // projectKey
                null, // environmentKey
                contextInstanceSearch,
                null, // limit
                null, // continuationToken
                null, // sort
                null, // filter
                null // includeTotalCount
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContextsApi#searchContextInstances");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
