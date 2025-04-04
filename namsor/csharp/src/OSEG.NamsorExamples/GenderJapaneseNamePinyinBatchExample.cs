using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class GenderJapaneseNamePinyinBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName"
        );

        var personalNames2 = new FirstLastNameIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName"
        );

        var personalNames = new List<FirstLastNameIn>
        {
            personalNames1,
            personalNames2,
        };

        var batchFirstLastNameIn = new BatchFirstLastNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new JapaneseApi(config).GenderJapaneseNamePinyinBatch(
                batchFirstLastNameIn: batchFirstLastNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling JapaneseApi#GenderJapaneseNamePinyinBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
