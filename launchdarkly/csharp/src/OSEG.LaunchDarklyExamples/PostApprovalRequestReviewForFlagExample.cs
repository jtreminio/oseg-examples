using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostApprovalRequestReviewForFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var postApprovalRequestReviewRequest = new PostApprovalRequestReviewRequest(
            kind: PostApprovalRequestReviewRequest.KindEnum.Approve,
            comment: "Looks good, thanks for updating"
        );

        try
        {
            var response = new ApprovalsApi(config).PostApprovalRequestReviewForFlag(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                id: null,
                postApprovalRequestReviewRequest: postApprovalRequestReviewRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApprovalsApi#PostApprovalRequestReviewForFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
