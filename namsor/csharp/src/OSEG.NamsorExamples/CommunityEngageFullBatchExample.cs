using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class CommunityEngageFullBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new PersonalNameGeoIn(
            id: "id",
            name: "name",
            countryIso2: "countryIso2"
        );

        var personalNames2 = new PersonalNameGeoIn(
            id: "id",
            name: "name",
            countryIso2: "countryIso2"
        );

        var personalNames = new List<PersonalNameGeoIn>
        {
            personalNames1,
            personalNames2,
        };

        var batchPersonalNameGeoIn = new BatchPersonalNameGeoIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).CommunityEngageFullBatch(
                batchPersonalNameGeoIn: batchPersonalNameGeoIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#CommunityEngageFullBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
