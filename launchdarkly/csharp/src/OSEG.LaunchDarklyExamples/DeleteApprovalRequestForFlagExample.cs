using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteApprovalRequestForFlagExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        try
        {
            new ApprovalsApi(config).DeleteApprovalRequestForFlag(
                projectKey: "projectKey_string",
                featureFlagKey: "featureFlagKey_string",
                environmentKey: "environmentKey_string",
                id: "id_string"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ApprovalsApi#DeleteApprovalRequestForFlag: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
