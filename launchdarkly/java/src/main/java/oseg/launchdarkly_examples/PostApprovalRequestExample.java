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

public class PostApprovalRequestExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var createApprovalRequestRequest = new CreateApprovalRequestRequest();
        createApprovalRequestRequest.resourceId("proj/projKey:env/envKey:flag/flagKey");
        createApprovalRequestRequest.description("Requesting to update targeting");
        createApprovalRequestRequest.instructions(List.of ());
        createApprovalRequestRequest.comment("optional comment");
        createApprovalRequestRequest.notifyMemberIds(List.of (
            "1234a56b7c89d012345e678f"
        ));
        createApprovalRequestRequest.notifyTeamKeys(List.of (
            "example-reviewer-team"
        ));
        createApprovalRequestRequest.integrationConfig(null);

        try
        {
            var response = new ApprovalsApi(config).postApprovalRequest(
                createApprovalRequestRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling Approvals#postApprovalRequest");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
