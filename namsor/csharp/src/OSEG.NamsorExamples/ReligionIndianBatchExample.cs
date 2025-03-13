using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class ReligionIndianBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameSubdivisionIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Akash",
            lastName: "Sharma",
            subdivisionIso: "IN-PB"
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
            var response = new IndianApi(config).ReligionIndianBatch(
                batchFirstLastNameSubdivisionIn: batchFirstLastNameSubdivisionIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling IndianApi#ReligionIndianBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
