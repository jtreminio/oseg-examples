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

public class CreateAContactExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();

        var publicContactCreateUpdatePayload = new PublicContactCreateUpdatePayload();
        publicContactCreateUpdatePayload.identifier(null);
        publicContactCreateUpdatePayload.identifierHash(null);
        publicContactCreateUpdatePayload.email(null);
        publicContactCreateUpdatePayload.name(null);
        publicContactCreateUpdatePayload.phoneNumber(null);
        publicContactCreateUpdatePayload.avatarUrl(null);

        try
        {
            var response = new ContactsApiApi(config).createAContact(
                null, // inboxIdentifier
                publicContactCreateUpdatePayload // data
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ContactsApiApi#createAContact");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
