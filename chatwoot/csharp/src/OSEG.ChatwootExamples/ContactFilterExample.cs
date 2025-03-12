using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class ContactFilterExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["userApiKey"] = "USER_API_KEY"};
        // config.ApiKey = new Dictionary<string, string> {["agentBotApiKey"] = "AGENT_BOT_API_KEY"};

        var contactFilterRequest = new ContactFilterRequest(
            payload: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "attribute_key": "name",
                        "filter_operator": "equal_to",
                        "query_operator": "AND",
                        "values": [
                            "en"
                        ]
                    },
                    {
                        "attribute_key": "country_code",
                        "filter_operator": "equal_to",
                        "query_operator": null,
                        "values": [
                            "us"
                        ]
                    }
                ]
            """)
        );

        try
        {
            var response = new ContactsApi(config).ContactFilter(
                accountId: null,
                body: contactFilterRequest,
                page: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ContactsApi#ContactFilter: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
