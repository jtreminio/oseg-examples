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

public class PatchMembersExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var membersPatchInput = new MembersPatchInput();
        membersPatchInput.instructions(JSON.deserialize("""
            [
                {
                    "kind": "replaceMembersRoles",
                    "memberIDs": [
                        "1234a56b7c89d012345e678f",
                        "507f1f77bcf86cd799439011"
                    ],
                    "value": "reader"
                }
            ]
        """, List.class));
        membersPatchInput.comment("Optional comment about the update");

        try
        {
            var response = new AccountMembersBetaApi(config).patchMembers(
                membersPatchInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AccountMembersBetaApi#patchMembers");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
