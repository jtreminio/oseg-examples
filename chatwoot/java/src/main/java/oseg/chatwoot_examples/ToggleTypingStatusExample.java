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

public class ToggleTypingStatusExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("platformAppApiKey")).setApiKey("PLATFORM_APP_API_KEY");

        try
        {
            new ConversationsApiApi(config).toggleTypingStatus(
                "inbox_identifier_string", // inboxIdentifier
                "contact_identifier_string", // contactIdentifier
                0, // conversationId
                "typing_status_string" // typingStatus
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling ConversationsApiApi#toggleTypingStatus");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
