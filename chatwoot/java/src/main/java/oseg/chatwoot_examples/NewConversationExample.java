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

public class NewConversationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");
        // config.setApiKey("AGENT_BOT_API_KEY");

        var messageTemplateParams = new NewConversationRequestMessageTemplateParams();
        messageTemplateParams.name("sample_issue_resolution");
        messageTemplateParams.category("UTILITY");
        messageTemplateParams.language("en_US");

        var message = new NewConversationRequestMessage();
        message.content(null);
        message.templateParams(messageTemplateParams);

        var newConversationRequest = new NewConversationRequest();
        newConversationRequest.inboxId(null);
        newConversationRequest.sourceId(null);
        newConversationRequest.contactId(null);
        newConversationRequest.status(null);
        newConversationRequest.assigneeId(null);
        newConversationRequest.teamId(null);
        newConversationRequest.message(message);

        try
        {
            var response = new ConversationsApi(config).newConversation(
                null, // accountId
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
