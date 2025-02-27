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

public class PostApprovalRequestApplyExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var postApprovalRequestApplyRequest = new PostApprovalRequestApplyRequest();
        postApprovalRequestApplyRequest.comment("Looks good, thanks for updating");

        try
        {
            var response = new ApprovalsApi(config).postApprovalRequestApply(
                null, // id
                postApprovalRequestApplyRequest
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ApprovalsApi#postApprovalRequestApply");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
