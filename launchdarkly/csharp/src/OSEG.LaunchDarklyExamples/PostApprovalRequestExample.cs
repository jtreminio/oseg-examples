using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostApprovalRequestExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var createApprovalRequestRequest = new CreateApprovalRequestRequest(
            resourceId: "proj/projKey:env/envKey:flag/flagKey",
            description: "Requesting to update targeting",
            instructions: new List<Dictionary<string, object>>(),
            comment: "optional comment",
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
            var response = new ApprovalsApi(config).PostApprovalRequest(
                createApprovalRequestRequest: createApprovalRequestRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApprovalsApi#PostApprovalRequest: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
