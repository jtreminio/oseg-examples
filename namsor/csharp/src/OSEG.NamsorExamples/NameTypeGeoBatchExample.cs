using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class NameTypeGeoBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var properNouns1 = new NameGeoIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name: "Edi Gathegi",
            countryIso2: "KE"
        );

        var properNouns = new List<NameGeoIn>
        {
            properNouns1,
        };

        var batchNameGeoIn = new BatchNameGeoIn(
            properNouns: properNouns
        );

        try
        {
            var response = new GeneralApi(config).NameTypeGeoBatch(
                batchNameGeoIn: batchNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling GeneralApi#NameTypeGeoBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
