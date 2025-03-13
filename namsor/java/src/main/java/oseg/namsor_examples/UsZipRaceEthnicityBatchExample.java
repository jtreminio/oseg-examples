package oseg.namsor_examples;

import app.namsor.client.ApiException;
import app.namsor.client.Configuration;
import app.namsor.client.api.*;
import app.namsor.client.auth.*;
import app.namsor.client.JSON;
import app.namsor.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class UsZipRaceEthnicityBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoZippedIn();
        personalNames1.id("728767f9-c5b2-4ed3-a071-828077f16552");
        personalNames1.firstName("Keith");
        personalNames1.lastName("Haring");
        personalNames1.countryIso2("US");
        personalNames1.zipCode("10019");

        var personalNames = new ArrayList<FirstLastNameGeoZippedIn>(List.of (
            personalNames1
        ));

        var batchFirstLastNameGeoZippedIn = new BatchFirstLastNameGeoZippedIn();
        batchFirstLastNameGeoZippedIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).usZipRaceEthnicityBatch(
                batchFirstLastNameGeoZippedIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#usZipRaceEthnicityBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
