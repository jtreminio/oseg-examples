using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class DeletePetExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.AccessToken = "YOUR_ACCESS_TOKEN";

        try
        {
            new PetApi(config).DeletePet(
                petId: 12345,
                apiKey: "df560d5ba4eb7adbc635c87c3931a8421ae24dc81646196cd66544fd4471414a"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling PetApi#DeletePet: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
