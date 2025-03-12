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

public class CreateAnIntegrationHookExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");
        // config.setApiKey("AGENT_BOT_API_KEY");
        // config.setApiKey("PLATFORM_APP_API_KEY");

        var integrationsHookCreatePayload = new IntegrationsHookCreatePayload();
        integrationsHookCreatePayload.appId(null);
        integrationsHookCreatePayload.inboxId(null);

        try
        {
            var response = new IntegrationsApi(config).createAnIntegrationHook(
                null, // accountId
                integrationsHookCreatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling IntegrationsApi#createAnIntegrationHook");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
