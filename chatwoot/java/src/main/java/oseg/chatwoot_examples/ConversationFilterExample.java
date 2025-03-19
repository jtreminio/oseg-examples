package oseg.chatwoot_examples;

import com.chatwoot.client.ApiException;
import com.chatwoot.client.Configuration;
import com.chatwoot.client.api.*;
import com.chatwoot.client.auth.*;
import com.chatwoot.client.JSON;
import com.chatwoot.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class ConversationFilterExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");

        var conversationFilterRequest = new ConversationFilterRequest();
        conversationFilterRequest.payload(JSON.deserialize("""
            [
                {
                    "attribute_key": "browser_language",
                    "filter_operator": "not_eq",
                    "query_operator": "AND",
                    "values": [
                        "en"
                    ]
                },
                {
                    "attribute_key": "status",
                    "filter_operator": "eq",
                    "query_operator": null,
                    "values": [
                        "pending"
                    ]
                }
            ]
        """, List.class));

        try
        {
            var response = new ConversationsApi(config).conversationFilter(
                0, // accountId
                conversationFilterRequest, // body
                null // page
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ConversationsApi#conversationFilter");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
