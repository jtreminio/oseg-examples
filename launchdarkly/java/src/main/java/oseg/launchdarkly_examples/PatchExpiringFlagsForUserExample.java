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

public class PatchExpiringFlagsForUserExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var instructions1 = new InstructionUserRequest();
        instructions1.kind(InstructionUserRequest.KindEnum.ADD_EXPIRE_USER_TARGET_DATE);
        instructions1.flagKey("sample-flag-key");
        instructions1.variationId("ce12d345-a1b2-4fb5-a123-ab123d4d5f5d");
        instructions1.value(16534692);
        instructions1.version(1);

        var instructions = new ArrayList<InstructionUserRequest>(List.of (
            instructions1
        ));

        var patchUsersRequest = new PatchUsersRequest();
        patchUsersRequest.comment("optional comment");
        patchUsersRequest.instructions(instructions);

        try
        {
            var response = new UserSettingsApi(config).patchExpiringFlagsForUser(
                "the-project-key", // projectKey
                "the-user-key", // userKey
                "the-environment-key", // environmentKey
                patchUsersRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling UserSettings#patchExpiringFlagsForUser");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
