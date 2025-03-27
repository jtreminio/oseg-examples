package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PostFlagCopyConfigApprovalRequestExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var source = new SourceFlag();
        source.key("environment-key-123abc");
        source.version(1);

        var createCopyFlagConfigApprovalRequestRequest = new CreateCopyFlagConfigApprovalRequestRequest();
        createCopyFlagConfigApprovalRequestRequest.description("copy flag settings to another environment");
        createCopyFlagConfigApprovalRequestRequest.comment("optional comment");
        createCopyFlagConfigApprovalRequestRequest.notifyMemberIds(List.of (
            "1234a56b7c89d012345e678f"
        ));
        createCopyFlagConfigApprovalRequestRequest.notifyTeamKeys(List.of (
            "example-reviewer-team"
        ));
        createCopyFlagConfigApprovalRequestRequest.includedActions(List.of (
            CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum.UPDATE_ON
        ));
        createCopyFlagConfigApprovalRequestRequest.excludedActions(List.of (
            CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum.UPDATE_ON
        ));
        createCopyFlagConfigApprovalRequestRequest.source(source);

        try
        {
            var response = new ApprovalsApi(config).postFlagCopyConfigApprovalRequest(
                "projectKey_string", // projectKey
                "featureFlagKey_string", // featureFlagKey
                "environmentKey_string", // environmentKey
                createCopyFlagConfigApprovalRequestRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ApprovalsApi#postFlagCopyConfigApprovalRequest");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
