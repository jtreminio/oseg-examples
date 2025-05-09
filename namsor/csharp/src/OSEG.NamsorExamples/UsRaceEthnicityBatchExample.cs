using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class UsRaceEthnicityBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoIn(
            id: "85dd5f48-b9e1-4019-88ce-ccc7e56b763f",
            firstName: "Keith",
            lastName: "Haring",
            countryIso2: "US"
        );

        var personalNames = new List<FirstLastNameGeoIn>
        {
            personalNames1,
        };

        var batchFirstLastNameGeoIn = new BatchFirstLastNameGeoIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).UsRaceEthnicityBatch(
                batchFirstLastNameGeoIn: batchFirstLastNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#UsRaceEthnicityBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
