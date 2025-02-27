using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class CountryBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new PersonalNameIn(
            id: "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
            name: "Keith Haring"
        );

        var personalNames = new List<PersonalNameIn>
        {
            personalNames1,
        };

        var batchPersonalNameIn = new BatchPersonalNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).CountryBatch(
                batchPersonalNameIn: batchPersonalNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#CountryBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
