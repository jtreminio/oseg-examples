using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class PhoneCodeGeoBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNamesWithPhoneNumbers1 = new FirstLastNamePhoneNumberGeoIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Teniola",
            lastName: "Apata",
            phoneNumber: "08186472651",
            countryIso2: "NG",
            countryIso2Alt: "CI"
        );

        var personalNamesWithPhoneNumbers = new List<FirstLastNamePhoneNumberGeoIn>
        {
            personalNamesWithPhoneNumbers1,
        };

        var batchFirstLastNamePhoneNumberGeoIn = new BatchFirstLastNamePhoneNumberGeoIn(
            personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers
        );

        try
        {
            var response = new SocialApi(config).PhoneCodeGeoBatch(
                batchFirstLastNamePhoneNumberGeoIn: batchFirstLastNamePhoneNumberGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SocialApi#PhoneCodeGeoBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
