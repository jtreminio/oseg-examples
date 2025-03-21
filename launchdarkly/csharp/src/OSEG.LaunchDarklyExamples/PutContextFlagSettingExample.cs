using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutContextFlagSettingExample
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
            new ContextSettingsApi(config).PutContextFlagSetting(
                projectKey: "projectKey_string",
                environmentKey: "environmentKey_string",
                contextKind: "contextKind_string",
                contextKey: "contextKey_string",
                featureFlagKey: "featureFlagKey_string",
                valuePut: valuePut
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContextSettingsApi#PutContextFlagSetting: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
