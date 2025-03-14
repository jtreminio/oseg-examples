using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class ReligionBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoSubdivisionIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName",
            countryIso2: "countryIso2",
            subdivisionIso: "subdivisionIso"
        );

        var personalNames2 = new FirstLastNameGeoSubdivisionIn(
            id: "id",
            firstName: "firstName",
            lastName: "lastName",
            countryIso2: "countryIso2",
            subdivisionIso: "subdivisionIso"
        );

        var personalNames = new List<FirstLastNameGeoSubdivisionIn>
        {
            personalNames1,
            personalNames2,
        };

        var batchFirstLastNameGeoSubdivisionIn = new BatchFirstLastNameGeoSubdivisionIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).ReligionBatch(
                batchFirstLastNameGeoSubdivisionIn: batchFirstLastNameGeoSubdivisionIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#ReligionBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
