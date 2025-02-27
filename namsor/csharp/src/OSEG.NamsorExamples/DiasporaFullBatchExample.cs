using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class DiasporaFullBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new PersonalNameGeoIn(
            id: "0d7d6417-0bbb-4205-951d-b3473f605b56",
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
            var response = new PersonalApi(config).DiasporaFullBatch(
                batchPersonalNameGeoIn: batchPersonalNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#DiasporaFullBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
