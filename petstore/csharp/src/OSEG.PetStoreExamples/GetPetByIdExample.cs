using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class GetPetByIdExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_key", "YOUR_API_KEY");

        try
        {
            var response = new PetApi(config).GetPetById(
                petId: 12345
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PetApi#GetPetById: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
