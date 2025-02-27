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

public class PostApprovalRequestForFlagExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var createFlagConfigApprovalRequestRequest = new CreateFlagConfigApprovalRequestRequest();
        createFlagConfigApprovalRequestRequest.description("Requesting to update targeting");
        createFlagConfigApprovalRequestRequest.instructions(List.of ());
        createFlagConfigApprovalRequestRequest.comment("optional comment");
        createFlagConfigApprovalRequestRequest.executionDate(1706701522000L);
        createFlagConfigApprovalRequestRequest.operatingOnId("6297ed79dee7dc14e1f9a80c");
        createFlagConfigApprovalRequestRequest.notifyMemberIds(List.of (
            "1234a56b7c89d012345e678f"
        ));
        createFlagConfigApprovalRequestRequest.notifyTeamKeys(List.of (
            "example-reviewer-team"
        ));
        createFlagConfigApprovalRequestRequest.integrationConfig(null);

        try
        {
            var response = new ApprovalsApi(config).postApprovalRequestForFlag(
                null, // projectKey
                null, // featureFlagKey
                null, // environmentKey
                createFlagConfigApprovalRequestRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ApprovalsApi#postApprovalRequestForFlag");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
