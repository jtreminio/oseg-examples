using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class DeleteOrderExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.AccessToken = "YOUR_ACCESS_TOKEN";
        // config.ApiKey.Add("api_key", "YOUR_API_KEY");

        try
        {
            new StoreApi(config).DeleteOrder(
                orderId: "12345"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling StoreApi#DeleteOrder: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
