using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class CountryFnLnBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameIn(
            id: "9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
            firstName: "Keith",
            lastName: "Haring"
        );

        var personalNames = new List<FirstLastNameIn>
        {
            personalNames1,
        };

        var batchFirstLastNameIn = new BatchFirstLastNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).CountryFnLnBatch(
                batchFirstLastNameIn: batchFirstLastNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#CountryFnLnBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
