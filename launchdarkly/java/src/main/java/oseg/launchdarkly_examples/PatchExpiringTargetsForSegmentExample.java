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

public class PatchExpiringTargetsForSegmentExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var instructions1 = new PatchSegmentExpiringTargetInstruction();
        instructions1.kind(PatchSegmentExpiringTargetInstruction.KindEnum.UPDATE_EXPIRING_TARGET);
        instructions1.contextKey("user@email.com");
        instructions1.contextKind("user");
        instructions1.targetType(PatchSegmentExpiringTargetInstruction.TargetTypeEnum.INCLUDED);
        instructions1.value(1587582000000L);
        instructions1.version(0);

        var instructions = new ArrayList<PatchSegmentExpiringTargetInstruction>(List.of (
            instructions1
        ));

        var patchSegmentExpiringTargetInputRep = new PatchSegmentExpiringTargetInputRep();
        patchSegmentExpiringTargetInputRep.comment("optional comment");
        patchSegmentExpiringTargetInputRep.instructions(instructions);

        try
        {
            var response = new SegmentsApi(config).patchExpiringTargetsForSegment(
                null, // projectKey
                null, // environmentKey
                null, // segmentKey
                patchSegmentExpiringTargetInputRep
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling SegmentsApi#patchExpiringTargetsForSegment");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
