using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class JapaneseNameKanjiCandidatesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        try
        {
            var response = new JapaneseApi(config).JapaneseNameKanjiCandidates(
                japaneseSurnameLatin: "Sanae",
                japaneseGivenNameLatin: "Yamamoto",
                knownGender: "m"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling JapaneseApi#JapaneseNameKanjiCandidates: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
