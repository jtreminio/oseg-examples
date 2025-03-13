using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutFlagSettingExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var valuePut = new ValuePut(
            comment: "make sure this context experiences a specific variation"
        );

        try
        {
            new UserSettingsApi(config).PutFlagSetting(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                userKey: "userKey_string",
                featureFlagKey: "featureFlagKey_string",
                valuePut: valuePut
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling UserSettingsApi#PutFlagSetting: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
