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

public class UpdateInboxExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");
        // config.setApiKey("AGENT_BOT_API_KEY");
        // config.setApiKey("PLATFORM_APP_API_KEY");

        var channel = new UpdateInboxRequestChannel();
        channel.websiteUrl(null);
        channel.welcomeTitle(null);
        channel.welcomeTagline(null);
        channel.agentAwayMessage(null);
        channel.widgetColor(null);

        var updateInboxRequest = new UpdateInboxRequest();
        updateInboxRequest.enableAutoAssignment(null);
        updateInboxRequest.name(null);
        updateInboxRequest.avatar(null);
        updateInboxRequest.channel(channel);

        try
        {
            var response = new InboxesApi(config).updateInbox(
                null, // accountId
                null, // id
                updateInboxRequest // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling InboxesApi#updateInbox");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
