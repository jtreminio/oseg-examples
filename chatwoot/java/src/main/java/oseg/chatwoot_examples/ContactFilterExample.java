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

public class ContactFilterExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");

        var payload1 = new ContactFilterRequestPayloadInner();
        payload1.attributeKey("name");
        payload1.filterOperator(ContactFilterRequestPayloadInner.FilterOperatorEnum.EQUAL_TO);
        payload1.queryOperator(ContactFilterRequestPayloadInner.QueryOperatorEnum.AND);
        payload1.values(List.of (
            "en"
        ));

        var payload2 = new ContactFilterRequestPayloadInner();
        payload2.attributeKey("country_code");
        payload2.filterOperator(ContactFilterRequestPayloadInner.FilterOperatorEnum.EQUAL_TO);
        payload2.values(List.of (
            "us"
        ));

        var payload = new ArrayList<ContactFilterRequestPayloadInner>(List.of (
            payload1,
            payload2
        ));

        var contactFilterRequest = new ContactFilterRequest();
        contactFilterRequest.payload(payload);

        try
        {
            var response = new ContactsApi(config).contactFilter(
                0, // accountId
                contactFilterRequest, // body
                null // page
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContactsApi#contactFilter");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
