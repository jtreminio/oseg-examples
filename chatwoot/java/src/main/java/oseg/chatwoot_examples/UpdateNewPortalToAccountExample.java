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

public class UpdateNewPortalToAccountExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("userApiKey")).setApiKey("USER_API_KEY");

        var portalCreateUpdatePayload = new PortalCreateUpdatePayload();
        portalCreateUpdatePayload.color("add color HEX string, \"#fffff\"");
        portalCreateUpdatePayload.customDomain("https://chatwoot.help/.");
        portalCreateUpdatePayload.headerText("Handbook");
        portalCreateUpdatePayload.homepageLink("https://www.chatwoot.com/");
        portalCreateUpdatePayload.config(JSON.deserialize("""
            {
                "allowed_locales": [
                    "en",
                    "es"
                ],
                "default_locale": "en"
            }
        """, Map.class));

        try
        {
            var response = new HelpCenterApi(config).updateNewPortalToAccount(
                0, // accountId
                portalCreateUpdatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling HelpCenterApi#updateNewPortalToAccount");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
