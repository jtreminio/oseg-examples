using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class GenderGeoExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        try
        {
            var response = new PersonalApi(config).GenderGeo(
                firstName: "Keith",
                lastName: "Haring",
                countryIso2: "US"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#GenderGeo: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
