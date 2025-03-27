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

public class SearchContextsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var contextSearch = new ContextSearch();
        contextSearch.filter("*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]");
        contextSearch.sort("-ts");
        contextSearch.limit(10);
        contextSearch.continuationToken("QAGFKH1313KUGI2351");

        try
        {
            var response = new ContextsApi(config).searchContexts(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                contextSearch,
                null, // limit
                null, // continuationToken
                null, // sort
                null, // filter
                null // includeTotalCount
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContextsApi#searchContexts");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
