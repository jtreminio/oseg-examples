using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class PinyinChineseNameBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new PersonalNameIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            name: "赵丽颖"
        );

        var personalNames = new List<PersonalNameIn>
        {
            personalNames1,
        };

        var batchPersonalNameIn = new BatchPersonalNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new ChineseApi(config).PinyinChineseNameBatch(
                batchPersonalNameIn: batchPersonalNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ChineseApi#PinyinChineseNameBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
