using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class AnonymizeExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        try
        {
            new AdminApi(config).Anonymize(
                source: "source",
                anonymized: true
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AdminApi#Anonymize: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
