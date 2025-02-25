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

public class PostModelConfigExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var modelConfigPost = new ModelConfigPost();
        modelConfigPost.id("id");
        modelConfigPost.key("key");
        modelConfigPost.name("name");
        modelConfigPost.icon("icon");
        modelConfigPost.provider("provider");
        modelConfigPost.tags(List.of (
            "tags",
            "tags"
        ));

        try
        {
            var response = new AIConfigsBetaApi(config).postModelConfig(
                null, // lDAPIVersion
                "default", // projectKey
                modelConfigPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AIConfigsBeta#postModelConfig");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
