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

public class AddNewAutomationRuleToAccountExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");

        var automationRuleCreateUpdatePayload = new AutomationRuleCreateUpdatePayload();
        automationRuleCreateUpdatePayload.name("Add label on message create event");
        automationRuleCreateUpdatePayload.description("Add label support and sales on message create event if incoming message content contains text help");
        automationRuleCreateUpdatePayload.eventName(AutomationRuleCreateUpdatePayload.EventNameEnum.MESSAGE_CREATED);
        automationRuleCreateUpdatePayload.actions(JSON.deserialize("""
            [
                {
                    "action_name": "add_label",
                    "action_params": [
                        "support"
                    ]
                }
            ]
        """, List.class));
        automationRuleCreateUpdatePayload.conditions(JSON.deserialize("""
            [
                {
                    "attribute_key": "content",
                    "filter_operator": "contains",
                    "query_operator": "nil",
                    "values": [
                        "help"
                    ]
                }
            ]
        """, List.class));

        try
        {
            var response = new AutomationRuleApi(config).addNewAutomationRuleToAccount(
                0, // accountId
                automationRuleCreateUpdatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling AutomationRuleApi#addNewAutomationRuleToAccount");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
