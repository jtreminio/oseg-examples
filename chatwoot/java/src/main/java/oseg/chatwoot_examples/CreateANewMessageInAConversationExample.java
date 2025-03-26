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

public class CreateANewMessageInAConversationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");
        // ((ApiKeyAuth) config.getAuthentication("agentBotApiKey")).setApiKey("AGENT_BOT_API_KEY");

        var templateParams = new NewConversationRequestMessageTemplateParams();
        templateParams.name("sample_issue_resolution");
        templateParams.category("UTILITY");
        templateParams.language("en_US");
        templateParams.processedParams(JSON.deserialize("""
            {
                "1": "Chatwoot"
            }
        """, Map.class));

        var conversationMessageCreate = new ConversationMessageCreate();
        conversationMessageCreate.content("content_string");
        conversationMessageCreate.contentType(ConversationMessageCreate.ContentTypeEnum.CARDS);
        conversationMessageCreate.templateParams(templateParams);

        try
        {
            var response = new MessagesApi(config).createANewMessageInAConversation(
                0, // accountId
                0, // conversationId
                conversationMessageCreate // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling MessagesApi#createANewMessageInAConversation");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
