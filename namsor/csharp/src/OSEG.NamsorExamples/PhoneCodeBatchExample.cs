using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class PhoneCodeBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNamesWithPhoneNumbers1 = new FirstLastNamePhoneNumberIn(
            id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
            firstName: "Jamini",
            lastName: "Roy",
            phoneNumber: "09804201420"
        );

        var personalNamesWithPhoneNumbers = new List<FirstLastNamePhoneNumberIn>
        {
            personalNamesWithPhoneNumbers1,
        };

        var batchFirstLastNamePhoneNumberIn = new BatchFirstLastNamePhoneNumberIn(
            personalNamesWithPhoneNumbers: personalNamesWithPhoneNumbers
        );

        try
        {
            var response = new SocialApi(config).PhoneCodeBatch(
                batchFirstLastNamePhoneNumberIn: batchFirstLastNamePhoneNumberIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SocialApi#PhoneCodeBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
