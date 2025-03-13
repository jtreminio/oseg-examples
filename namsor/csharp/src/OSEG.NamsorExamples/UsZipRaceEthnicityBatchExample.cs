using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class UsZipRaceEthnicityBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoZippedIn(
            id: "728767f9-c5b2-4ed3-a071-828077f16552",
            firstName: "Keith",
            lastName: "Haring",
            countryIso2: "US",
            zipCode: "10019"
        );

        var personalNames = new List<FirstLastNameGeoZippedIn>
        {
            personalNames1,
        };

        var batchFirstLastNameGeoZippedIn = new BatchFirstLastNameGeoZippedIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).UsZipRaceEthnicityBatch(
                batchFirstLastNameGeoZippedIn: batchFirstLastNameGeoZippedIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#UsZipRaceEthnicityBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
