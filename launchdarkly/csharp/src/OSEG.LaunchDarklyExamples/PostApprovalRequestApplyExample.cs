using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostApprovalRequestApplyExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var postApprovalRequestApplyRequest = new PostApprovalRequestApplyRequest(
            comment: "Looks good, thanks for updating"
        );

        try
        {
            var response = new ApprovalsApi(config).PostApprovalRequestApply(
                id: null,
                postApprovalRequestApplyRequest: postApprovalRequestApplyRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApprovalsApi#PostApprovalRequestApply: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
