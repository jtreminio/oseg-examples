package oseg.petstore_examples;

import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.api.*;
import org.openapitools.client.auth.*;
import org.openapitools.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class LoginUserExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setAccessToken("YOUR_ACCESS_TOKEN");
        // config.setApiKey("YOUR_API_KEY");

        try
        {
            var response = new UserApi(config).loginUser(
                "my_username", // username
                "my_secret_password" // password
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling User#loginUser");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
