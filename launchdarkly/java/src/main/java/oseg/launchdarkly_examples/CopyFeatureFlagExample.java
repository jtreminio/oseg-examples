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

public class CopyFeatureFlagExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var source = new FlagCopyConfigEnvironment();
        source.key("source-env-key-123abc");
        source.currentVersion(1);

        var target = new FlagCopyConfigEnvironment();
        target.key("target-env-key-123abc");
        target.currentVersion(1);

        var flagCopyConfigPost = new FlagCopyConfigPost();
        flagCopyConfigPost.comment("optional comment");
        flagCopyConfigPost.source(source);
        flagCopyConfigPost.target(target);

        try
        {
            var response = new FeatureFlagsApi(config).copyFeatureFlag(
                null, // projectKey
                null, // featureFlagKey
                flagCopyConfigPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling FeatureFlagsApi#copyFeatureFlag");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
