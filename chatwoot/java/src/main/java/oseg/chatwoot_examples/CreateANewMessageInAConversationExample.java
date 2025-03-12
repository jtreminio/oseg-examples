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
        config.setApiKey("USER_API_KEY");
        // config.setApiKey("AGENT_BOT_API_KEY");

        var templateParams = new ConversationMessageCreateTemplateParams();
        templateParams.name("sample_issue_resolution");
        templateParams.category("UTILITY");
        templateParams.language("en_US");

        var conversationMessageCreate = new ConversationMessageCreate();
        conversationMessageCreate.content(null);
        conversationMessageCreate.messageType(null);
        conversationMessageCreate._private(null);
        conversationMessageCreate.contentType(ConversationMessageCreate.ContentTypeEnum.CARDS);
        conversationMessageCreate.templateParams(templateParams);

        try
        {
            var response = new MessagesApi(config).createANewMessageInAConversation(
                null, // accountId
                null, // conversationId
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
