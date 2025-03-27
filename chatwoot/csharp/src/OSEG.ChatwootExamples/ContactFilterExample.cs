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
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");

        var payload1 = new ContactFilterRequestPayloadInner(
            attributeKey: "name",
            filterOperator: ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
            queryOperator: ContactFilterRequestPayloadInner.QueryOperatorEnum.AND,
            values: [
                "en",
            ]
        );

        var payload2 = new ContactFilterRequestPayloadInner(
            attributeKey: "country_code",
            filterOperator: ContactFilterRequestPayloadInner.FilterOperatorEnum.EqualTo,
            values: [
                "us",
            ]
        );

        var payload = new List<ContactFilterRequestPayloadInner>
        {
            payload1,
            payload2,
        };

        var contactFilterRequest = new ContactFilterRequest(
            payload: payload
        );

        try
        {
            var response = new ContactsApi(config).ContactFilter(
                accountId: 0,
                body: contactFilterRequest
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
