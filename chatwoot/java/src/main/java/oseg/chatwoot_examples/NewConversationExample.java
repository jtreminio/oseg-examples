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

public class NewConversationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");

        var messageTemplateParams = new NewConversationRequestMessageTemplateParams();
        messageTemplateParams.name("sample_issue_resolution");
        messageTemplateParams.category("UTILITY");
        messageTemplateParams.language("en_US");
        messageTemplateParams.processedParams(JSON.deserialize("""
            {
                "1": "Chatwoot"
            }
        """, Map.class));

        var message = new NewConversationRequestMessage();
        message.content("content_string");
        message.templateParams(messageTemplateParams);

        var newConversationRequest = new NewConversationRequest();
        newConversationRequest.inboxId("inbox_id_string");
        newConversationRequest.sourceId("source_id_string");
        newConversationRequest.customAttributes(JSON.deserialize("""
            {
                "attribute_key": "attribute_value",
                "priority_conversation_number": 3
            }
        """, Map.class));
        newConversationRequest.message(message);

        try
        {
            var response = new ConversationsApi(config).newConversation(
                0, // accountId
                newConversationRequest // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ConversationsApi#newConversation");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
