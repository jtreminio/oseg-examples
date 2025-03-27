package oseg.petstore_examples;

import org.openapitools.client.ApiException;
import org.openapitools.client.Configuration;
import org.openapitools.client.api.*;
import org.openapitools.client.auth.*;
import org.openapitools.client.JSON;
import org.openapitools.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class FindPetsByStatusExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((HttpBearerAuth) config.getAuthentication("petstore_auth")).setBearerToken("YOUR_ACCESS_TOKEN");

        try
        {
            var response = new PetApi(config).findPetsByStatus(
                List.of (
                    "available",
                    "pending"
                ) // status
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PetApi#findPetsByStatus");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
