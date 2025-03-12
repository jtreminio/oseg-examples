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

public class CreateACustomFilterExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("USER_API_KEY");
        // config.setApiKey("AGENT_BOT_API_KEY");
        // config.setApiKey("PLATFORM_APP_API_KEY");

        var customFilterCreateUpdatePayload = new CustomFilterCreateUpdatePayload();
        customFilterCreateUpdatePayload.name(null);
        customFilterCreateUpdatePayload.type(null);

        try
        {
            var response = new CustomFiltersApi(config).createACustomFilter(
                null, // accountId
                customFilterCreateUpdatePayload, // data
                null // filterType
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling CustomFiltersApi#createACustomFilter");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
