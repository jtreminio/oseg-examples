using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class CastegroupIndianFullBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new PersonalNameSubdivisionIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name: "Akash Sharma",
            subdivisionIso: "IN-UP"
        );

        var personalNames = new List<PersonalNameSubdivisionIn>
        {
            personalNames1,
        };

        var batchPersonalNameSubdivisionIn = new BatchPersonalNameSubdivisionIn(
            personalNames: personalNames
        );

        try
        {
            var response = new IndianApi(config).CastegroupIndianFullBatch(
                batchPersonalNameSubdivisionIn: batchPersonalNameSubdivisionIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IndianApi#CastegroupIndianFullBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
