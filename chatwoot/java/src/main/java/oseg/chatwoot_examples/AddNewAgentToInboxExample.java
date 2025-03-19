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

public class AddNewAgentToInboxExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");

        var addNewAgentToInboxRequest = new AddNewAgentToInboxRequest();
        addNewAgentToInboxRequest.inboxId("inbox_id_string");
        addNewAgentToInboxRequest.userIds(List.of ());

        try
        {
            var response = new InboxesApi(config).addNewAgentToInbox(
                0, // accountId
                addNewAgentToInboxRequest // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling InboxesApi#addNewAgentToInbox");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
