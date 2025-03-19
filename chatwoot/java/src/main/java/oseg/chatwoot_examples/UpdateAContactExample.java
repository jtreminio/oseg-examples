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

public class UpdateAContactExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();

        var publicContactCreateUpdatePayload = new PublicContactCreateUpdatePayload();

        try
        {
            var response = new ContactsApiApi(config).updateAContact(
                "inbox_identifier_string", // inboxIdentifier
                "contact_identifier_string", // contactIdentifier
                publicContactCreateUpdatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContactsApiApi#updateAContact");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
