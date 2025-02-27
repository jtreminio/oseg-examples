using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class NameTypeBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var properNouns1 = new NameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name: "Zippo"
        );

        var properNouns = new List<NameIn>
        {
            properNouns1,
        };

        var batchNameIn = new BatchNameIn(
            properNouns: properNouns
        );

        try
        {
            var response = new GeneralApi(config).NameTypeBatch(
                batchNameIn: batchNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling GeneralApi#NameTypeBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
