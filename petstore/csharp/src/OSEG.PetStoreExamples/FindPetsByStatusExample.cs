using System;
using System.Collections.Generic;
using System.IO;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class FindPetsByStatusExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.AccessToken = "YOUR_ACCESS_TOKEN";

        try
        {
            var response = new PetApi(config).FindPetsByStatus(
                status: [
                    "available",
                    "pending",
                ]
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Pet#FindPetsByStatus: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
