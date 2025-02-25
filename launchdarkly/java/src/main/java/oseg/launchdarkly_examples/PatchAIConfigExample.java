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

public class PatchAIConfigExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var aIConfigPatch = new AIConfigPatch();
        aIConfigPatch.description("description");
        aIConfigPatch.name("name");
        aIConfigPatch.tags(List.of (
            "tags",
            "tags"
        ));

        try
        {
            var response = new AIConfigsBetaApi(config).patchAIConfig(
                null, // lDAPIVersion
                null, // projectKey
                null, // configKey
                aIConfigPatch
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AIConfigsBeta#patchAIConfig");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
