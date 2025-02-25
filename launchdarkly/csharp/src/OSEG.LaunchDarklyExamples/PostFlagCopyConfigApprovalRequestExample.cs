using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostFlagCopyConfigApprovalRequestExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var source = new SourceFlag(
            key: "environment-key-123abc",
            varVersion: 1
        );

        var createCopyFlagConfigApprovalRequestRequest = new CreateCopyFlagConfigApprovalRequestRequest(
            description: "copy flag settings to another environment",
            comment: "optional comment",
            notifyMemberIds: [
                "1234a56b7c89d012345e678f",
            ],
            notifyTeamKeys: [
                "example-reviewer-team",
            ],
            includedActions: [
                CreateCopyFlagConfigApprovalRequestRequest.IncludedActionsEnum.UpdateOn,
            ],
            excludedActions: [
                CreateCopyFlagConfigApprovalRequestRequest.ExcludedActionsEnum.UpdateOn,
            ],
            source: source
        );

        try
        {
            var response = new ApprovalsApi(config).PostFlagCopyConfigApprovalRequest(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                createCopyFlagConfigApprovalRequestRequest: createCopyFlagConfigApprovalRequestRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Approvals#PostFlagCopyConfigApprovalRequest: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
