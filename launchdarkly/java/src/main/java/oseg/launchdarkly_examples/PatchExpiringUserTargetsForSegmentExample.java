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

public class PatchExpiringUserTargetsForSegmentExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var instructions1 = new PatchSegmentInstruction();
        instructions1.kind(PatchSegmentInstruction.KindEnum.ADD_EXPIRE_USER_TARGET_DATE);
        instructions1.userKey("sample-user-key");
        instructions1.targetType(PatchSegmentInstruction.TargetTypeEnum.INCLUDED);
        instructions1.value(16534692);
        instructions1.version(0);

        var instructions = new ArrayList<PatchSegmentInstruction>(List.of (
            instructions1
        ));

        var patchSegmentRequest = new PatchSegmentRequest();
        patchSegmentRequest.comment("optional comment");
        patchSegmentRequest.instructions(instructions);

        try
        {
            var response = new SegmentsApi(config).patchExpiringUserTargetsForSegment(
                "the-project-key", // projectKey
                "the-environment-key", // environmentKey
                "the-segment-key", // segmentKey
                patchSegmentRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling Segments#patchExpiringUserTargetsForSegment");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
