using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class ChineseNameCandidatesBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "LiYing",
            lastName: "Zhao"
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
            var response = new ChineseApi(config).ChineseNameCandidatesBatch(
                batchFirstLastNameIn: batchFirstLastNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ChineseApi#ChineseNameCandidatesBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
