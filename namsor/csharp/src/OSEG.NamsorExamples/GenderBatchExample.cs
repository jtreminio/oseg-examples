using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class GenderBatchExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        var personalNames1 = new FirstLastNameIn(
            id: "b590b04c-da23-4f2f-a334-aee384ee420a",
            firstName: "Keith",
            lastName: "Haring"
        );

        var personalNames = new List<FirstLastNameIn>
        {
            personalNames1,
        };

        var batchFirstLastNameIn = new BatchFirstLastNameIn(
            personalNames: personalNames
        );

        try
        {
            var response = new PersonalApi(config).GenderBatch(
                batchFirstLastNameIn: batchFirstLastNameIn
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PersonalApi#GenderBatch: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
