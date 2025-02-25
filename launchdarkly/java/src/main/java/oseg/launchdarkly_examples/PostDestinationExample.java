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

public class PostDestinationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var destinationPost = new DestinationPost();
        destinationPost.kind(DestinationPost.KindEnum.GOOGLE_PUBSUB);

        try
        {
            var response = new DataExportDestinationsApi(config).postDestination(
                null, // projectKey
                null, // environmentKey
                destinationPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling DataExportDestinations#postDestination");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
