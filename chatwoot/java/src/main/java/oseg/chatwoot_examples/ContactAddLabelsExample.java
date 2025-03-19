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

public class ContactAddLabelsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("platformAppApiKey")).setApiKey("PLATFORM_APP_API_KEY");

        var contactAddLabelsRequest = new ContactAddLabelsRequest();
        contactAddLabelsRequest.labels(List.of ());

        try
        {
            var response = new ContactLabelsApi(config).contactAddLabels(
                0, // accountId
                "contact_identifier_string", // contactIdentifier
                contactAddLabelsRequest // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContactLabelsApi#contactAddLabels");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
