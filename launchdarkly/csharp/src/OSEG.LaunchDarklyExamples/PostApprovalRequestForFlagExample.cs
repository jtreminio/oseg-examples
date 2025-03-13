using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostApprovalRequestForFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var createFlagConfigApprovalRequestRequest = new CreateFlagConfigApprovalRequestRequest(
            description: "Requesting to update targeting",
            instructions: new List<Dictionary<string, object>>(),
            comment: "optional comment",
            executionDate: 1706701522000,
            operatingOnId: "6297ed79dee7dc14e1f9a80c",
            notifyMemberIds: [
                "1234a56b7c89d012345e678f",
            ],
            notifyTeamKeys: [
                "example-reviewer-team",
            ],
            integrationConfig: null
        );

        try
        {
            var response = new ApprovalsApi(config).PostApprovalRequestForFlag(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                createFlagConfigApprovalRequestRequest: createFlagConfigApprovalRequestRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApprovalsApi#PostApprovalRequestForFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
