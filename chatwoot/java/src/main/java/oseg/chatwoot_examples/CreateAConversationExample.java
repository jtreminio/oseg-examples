package oseg.chatwoot_examples;

import com.chatwoot.client.ApiException;
import com.chatwoot.client.Configuration;
import com.chatwoot.client.api.*;
import com.chatwoot.client.auth.*;
import com.chatwoot.client.JSON;
import com.chatwoot.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class CreateAConversationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();

        var publicConversationCreatePayload = new PublicConversationCreatePayload();

        try
        {
            var response = new ConversationsApiApi(config).createAConversation(
                "inbox_identifier_string", // inboxIdentifier
                "contact_identifier_string", // contactIdentifier
                publicConversationCreatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ConversationsApiApi#createAConversation");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
