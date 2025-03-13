using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PatchExpiringFlagsForUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var instructions1 = new InstructionUserRequest(
            kind: InstructionUserRequest.KindEnum.AddExpireUserTargetDate,
            flagKey: "sample-flag-key",
            variationId: "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d",
            value: 16534692,
            varVersion: 1
        );

        var instructions = new List<InstructionUserRequest>
        {
            instructions1,
        };

        var patchUsersRequest = new PatchUsersRequest(
            comment: "optional comment",
            instructions: instructions
        );

        try
        {
            var response = new UserSettingsApi(config).PatchExpiringFlagsForUser(
                projectKey: "the-project-key",
                userKey: "the-user-key",
                environmentKey: "the-environment-key",
                patchUsersRequest: patchUsersRequest
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling UserSettingsApi#PatchExpiringFlagsForUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
