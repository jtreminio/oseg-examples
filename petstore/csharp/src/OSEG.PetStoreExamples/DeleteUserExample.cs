using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class DeleteUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_key", "YOUR_API_KEY");

        try
        {
            new UserApi(config).DeleteUser(
                username: "my_username"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling UserApi#DeleteUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
