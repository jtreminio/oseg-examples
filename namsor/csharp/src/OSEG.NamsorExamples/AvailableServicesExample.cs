using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using App.Namsor.Api;
using App.Namsor.Client;
using App.Namsor.Model;

namespace OSEG.NamsorExamples;

public class AvailableServicesExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("X-API-KEY", "YOUR_API_KEY");

        try
        {
            var response = new AdminApi(config).AvailableServices();

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AdminApi#AvailableServices: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
