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

public class CreateFlagImportConfigurationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var flagImportConfigurationPost = new FlagImportConfigurationPost();
        flagImportConfigurationPost.config(JSON.deserialize("""
            {
                "environmentId": "The ID of the environment in the external system",
                "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
                "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
                "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
                "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
                "workspaceApiKey": "An API key with read permissions in the external feature management system",
                "workspaceId": "The ID of the workspace in the external system"
            }
        """, Map.class));
        flagImportConfigurationPost.name("Sample configuration");
        flagImportConfigurationPost.tags(List.of (
            "example-tag"
        ));

        try
        {
            var response = new FlagImportConfigurationsBetaApi(config).createFlagImportConfiguration(
                null, // projectKey
                null, // integrationKey
                flagImportConfigurationPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
