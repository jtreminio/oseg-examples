using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class SubclassificationIndianBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameGeoIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Jannat",
            lastName: "Rahmani"
        );

        var personalNames = new List<FirstLastNameGeoIn>
        {
            personalNames1,
        };

        var batchFirstLastNameGeoIn = new BatchFirstLastNameGeoIn(
            personalNames: personalNames
        );

        try
        {
            var response = new IndianApi(config).SubclassificationIndianBatch(
                batchFirstLastNameGeoIn: batchFirstLastNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IndianApi#SubclassificationIndianBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
