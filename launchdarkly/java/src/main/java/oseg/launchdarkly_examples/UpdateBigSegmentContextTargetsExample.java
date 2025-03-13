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

public class UpdateBigSegmentContextTargetsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var included = new SegmentUserList();
        included.add(List.of ());
        included.remove(List.of ());

        var excluded = new SegmentUserList();
        excluded.add(List.of ());
        excluded.remove(List.of ());

        var segmentUserState = new SegmentUserState();
        segmentUserState.included(included);
        segmentUserState.excluded(excluded);

        try
        {
            new SegmentsApi(config).updateBigSegmentContextTargets(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                "segmentKey_string", // segmentKey
                segmentUserState
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling SegmentsApi#updateBigSegmentContextTargets");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
