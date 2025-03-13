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

public class PatchSegmentExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var patch1 = new PatchOperation();
        patch1.op("replace");
        patch1.path("/description");

        var patch2 = new PatchOperation();
        patch2.op("add");
        patch2.path("/tags/0");

        var patch = new ArrayList<PatchOperation>(List.of (
            patch1,
            patch2
        ));

        var patchWithComment = new PatchWithComment();
        patchWithComment.patch(patch);

        try
        {
            var response = new SegmentsApi(config).patchSegment(
                null, // projectKey
                null, // environmentKey
                null, // segmentKey
                patchWithComment
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling SegmentsApi#patchSegment");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
