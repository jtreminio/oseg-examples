using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PutExperimentationSettingsExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var randomizationUnits1 = new RandomizationUnitInput(
            randomizationUnit: "user",
            standardRandomizationUnit: RandomizationUnitInput.StandardRandomizationUnitEnum.Organization
        );

        var randomizationUnits = new List<RandomizationUnitInput>
        {
            randomizationUnits1,
        };

        var randomizationSettingsPut = new RandomizationSettingsPut(
            randomizationUnits: randomizationUnits
        );

        try
        {
            var response = new ExperimentsApi(config).PutExperimentationSettings(
                projectKey: "the-project-key",
                randomizationSettingsPut: randomizationSettingsPut
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ExperimentsApi#PutExperimentationSettings: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
