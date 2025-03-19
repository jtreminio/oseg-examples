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

public class DeleteAnAccountExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("platformAppApiKey")).setApiKey("PLATFORM_APP_API_KEY");

        try
        {
            new AccountsApi(config).deleteAnAccount(
                0 // accountId
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling AccountsApi#deleteAnAccount");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
