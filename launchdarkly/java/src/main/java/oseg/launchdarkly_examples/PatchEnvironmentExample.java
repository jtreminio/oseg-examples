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

public class PatchEnvironmentExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var patchOperation1 = new PatchOperation();
        patchOperation1.op("replace");
        patchOperation1.path("/requireComments");

        var patchOperation = new ArrayList<PatchOperation>(List.of (
            patchOperation1
        ));

        try
        {
            var response = new EnvironmentsApi(config).patchEnvironment(
                null, // projectKey
                null, // environmentKey
                patchOperation
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling EnvironmentsApi#patchEnvironment");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
