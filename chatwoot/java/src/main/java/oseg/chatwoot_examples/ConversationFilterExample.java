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

public class ConversationFilterExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");

        var payload1 = new ContactFilterRequestPayloadInner();
        payload1.attributeKey("browser_language");
        payload1.filterOperator(ContactFilterRequestPayloadInner.FilterOperatorEnum.NOT_EQUAL_TO);
        payload1.queryOperator(ContactFilterRequestPayloadInner.QueryOperatorEnum.AND);
        payload1.values(List.of (
            "en"
        ));

        var payload2 = new ContactFilterRequestPayloadInner();
        payload2.attributeKey("status");
        payload2.filterOperator(ContactFilterRequestPayloadInner.FilterOperatorEnum.EQUAL_TO);
        payload2.values(List.of (
            "pending"
        ));

        var payload = new ArrayList<ContactFilterRequestPayloadInner>(List.of (
            payload1,
            payload2
        ));

        var conversationFilterRequest = new ConversationFilterRequest();
        conversationFilterRequest.payload(payload);

        try
        {
            var response = new ConversationsApi(config).conversationFilter(
                123, // accountId
                conversationFilterRequest, // body
                1 // page
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
