using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class ChineseNameCandidatesGenderBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameGenderIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "LiYing",
            lastName: "Zhao",
            gender: "female"
        );

        var personalNames = new List<FirstLastNameGenderIn>
        {
            personalNames1,
        };

        var batchFirstLastNameGenderIn = new BatchFirstLastNameGenderIn(
            personalNames: personalNames
        );

        try
        {
            var response = new ChineseApi(config).ChineseNameCandidatesGenderBatch(
                batchFirstLastNameGenderIn: batchFirstLastNameGenderIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ChineseApi#ChineseNameCandidatesGenderBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
