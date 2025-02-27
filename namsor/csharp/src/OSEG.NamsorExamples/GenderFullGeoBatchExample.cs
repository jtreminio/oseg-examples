using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class GenderFullGeoBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new PersonalNameGeoIn(
            id: "3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f",
            name: "Keith Haring",
            countryIso2: "US"
        );

        var personalNames = new List<PersonalNameGeoIn>
        {
            personalNames1,
        };

        var batchPersonalNameGeoIn = new BatchPersonalNameGeoIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).GenderFullGeoBatch(
                batchPersonalNameGeoIn: batchPersonalNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#GenderFullGeoBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
