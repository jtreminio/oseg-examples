using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class LoginUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.AccessToken = "YOUR_ACCESS_TOKEN";
        // config.ApiKey.Add("api_key", "YOUR_API_KEY");

        try
        {
            var response = new UserApi(config).LoginUser(
                username: "my_username",
                password: "my_secret_password"
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling UserApi#LoginUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
