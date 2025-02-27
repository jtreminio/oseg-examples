using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class CastegroupIndianBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameSubdivisionIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Akash",
            lastName: "Sharma",
            subdivisionIso: "IN-UP"
        );

        var personalNames = new List<FirstLastNameSubdivisionIn>
        {
            personalNames1,
        };

        var batchFirstLastNameSubdivisionIn = new BatchFirstLastNameSubdivisionIn(
            personalNames: personalNames
        );

        try
        {
            var response = new IndianApi(config).CastegroupIndianBatch(
                batchFirstLastNameSubdivisionIn: batchFirstLastNameSubdivisionIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IndianApi#CastegroupIndianBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
