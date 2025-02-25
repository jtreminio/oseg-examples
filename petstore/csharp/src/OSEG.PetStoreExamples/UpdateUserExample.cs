using System;
using System.Collections.Generic;
using System.IO;

using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace OSEG.PetStoreExamples;

public class UpdateUserExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["api_key"] = "YOUR_API_KEY"};

        var user = new User(
            id: 12345,
            username: "new-username",
            firstName: "Joe",
            lastName: "Broke",
            email: "some-email@example.com",
            password: "so secure omg",
            phone: "555-867-5309",
            userStatus: 1
        );

        try
        {
            new UserApi(config).UpdateUser(
                username: "my-username",
                user: user
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling User#UpdateUser: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
