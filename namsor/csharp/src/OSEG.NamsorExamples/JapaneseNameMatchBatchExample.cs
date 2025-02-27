using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class JapaneseNameMatchBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1Name1 = new FirstLastNameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Tessai",
            lastName: "Tomioka"
        );

        var personalNames1Name2 = new PersonalNameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c43",
            name: "富岡 鉄斎"
        );

        var personalNames1 = new MatchPersonalFirstLastNameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c41",
            name1: personalNames1Name1,
            name2: personalNames1Name2
        );

        var personalNames = new List<MatchPersonalFirstLastNameIn>
        {
            personalNames1,
        };

        var batchMatchPersonalFirstLastNameIn = new BatchMatchPersonalFirstLastNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new JapaneseApi(config).JapaneseNameMatchBatch(
                batchMatchPersonalFirstLastNameIn: batchMatchPersonalFirstLastNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling JapaneseApi#JapaneseNameMatchBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
