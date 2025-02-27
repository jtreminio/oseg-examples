using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class GenderGeoBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new FirstLastNameGeoIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName",
            countryIso2: "countryIso2"
        );

        var personalNames2 = new FirstLastNameGeoIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName",
            countryIso2: "countryIso2"
        );

        var personalNames = new List<FirstLastNameGeoIn>
        {
            personalNames1,
            personalNames2,
        };

        var batchFirstLastNameGeoIn = new BatchFirstLastNameGeoIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).GenderGeoBatch(
                batchFirstLastNameGeoIn: batchFirstLastNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#GenderGeoBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
