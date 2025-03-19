using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Com.Chatwoot.Api;
using Com.Chatwoot.Client;
using Com.Chatwoot.Model;

namespace OSEG.ChatwootExamples;

public class ToggleTypingStatusExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey.Add("api_access_token", "USER_API_KEY");
        // config.ApiKey.Add("api_access_token", "AGENT_BOT_API_KEY");
        // config.ApiKey.Add("api_access_token", "PLATFORM_APP_API_KEY");

        try
        {
            new ConversationsAPIApi(config).ToggleTypingStatus(
                inboxIdentifier: "inbox_identifier_string",
                contactIdentifier: "contact_identifier_string",
                conversationId: 0,
                typingStatus: "typing_status_string"
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling ConversationsAPIApi#ToggleTypingStatus: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
