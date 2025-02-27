using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class PhoneCodeGeoFeedbackLoopExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        try
        {
            var response = new SocialApi(config).PhoneCodeGeoFeedbackLoop(
                firstName: "Teniola",
                lastName: "Apata",
                phoneNumber: "08186472651",
                phoneNumberE164: "",
                countryIso2: "NG"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling SocialApi#PhoneCodeGeoFeedbackLoop: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
