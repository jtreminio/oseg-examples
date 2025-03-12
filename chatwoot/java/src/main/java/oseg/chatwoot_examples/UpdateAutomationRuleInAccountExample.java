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

public class UpdateAutomationRuleInAccountExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");

        var automationRuleCreateUpdatePayload = new AutomationRuleCreateUpdatePayload();
        automationRuleCreateUpdatePayload.name("Add label on message create event");
        automationRuleCreateUpdatePayload.description("Add label support and sales on message create event if incoming message content contains text help");
        automationRuleCreateUpdatePayload.eventName(AutomationRuleCreateUpdatePayload.EventNameEnum.MESSAGE_CREATED);
        automationRuleCreateUpdatePayload.active(null);

        try
        {
            var response = new AutomationRuleApi(config).updateAutomationRuleInAccount(
                null, // accountId
                null, // id
                automationRuleCreateUpdatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AutomationRuleApi#updateAutomationRuleInAccount");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
