using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class ReligionFullBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var personalNames1 = new PersonalNameGeoSubdivisionIn(
            id: "id",
            name: "name",
            countryIso2: "countryIso2",
            subdivisionIso: "subdivisionIso"
        );

        var personalNames2 = new PersonalNameGeoSubdivisionIn(
            id: "id",
            name: "name",
            countryIso2: "countryIso2",
            subdivisionIso: "subdivisionIso"
        );

        var personalNames = new List<PersonalNameGeoSubdivisionIn>
        {
            personalNames1,
            personalNames2,
        };

        var batchPersonalNameGeoSubdivisionIn = new BatchPersonalNameGeoSubdivisionIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).ReligionFullBatch(
                batchPersonalNameGeoSubdivisionIn: batchPersonalNameGeoSubdivisionIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#ReligionFullBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
