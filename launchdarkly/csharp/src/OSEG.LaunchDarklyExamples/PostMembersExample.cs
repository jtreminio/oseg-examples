using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostMembersExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("Authorization", "YOUR_API_KEY");

        var newMemberForm1 = new NewMemberForm(
            email: "sandy@acme.com",
            password: "***",
            firstName: "Ariel",
            lastName: "Flores",
            role: NewMemberForm.RoleEnum.Reader,
            customRoles: [
                "customRole1",
                "customRole2",
            ],
            teamKeys: [
                "team-1",
                "team-2",
            ],
            roleAttributes: null
        );

        var newMemberForm = new List<NewMemberForm>
        {
            newMemberForm1,
        };

        try
        {
            var response = new AccountMembersApi(config).PostMembers(
                newMemberForm: newMemberForm
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling AccountMembersApi#PostMembers: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
