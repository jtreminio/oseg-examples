package oseg.petstore_examples;

import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.api.*;
import org.openapitools.client.auth.*;
import org.openapitools.client.JSON;
import org.openapitools.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class UpdateUserExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var user = new User();
        user.id(12345L);
        user.username("new-username");
        user.firstName("Joe");
        user.lastName("Broke");
        user.email("some-email@example.com");
        user.password("so secure omg");
        user.phone("555-867-5309");
        user.userStatus(1);

        try
        {
            new UserApi(config).updateUser(
                "my-username", // username
                user
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling User#updateUser");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
