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

public class UsRaceEthnicityFullBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new PersonalNameGeoIn();
        personalNames1.id("85dd5f48-b9e1-4019-88ce-ccc7e56b763f");
        personalNames1.name("Keith Haring");
        personalNames1.countryIso2("US");

        var personalNames = new ArrayList<PersonalNameGeoIn>(List.of (
            personalNames1
        ));

        var batchPersonalNameGeoIn = new BatchPersonalNameGeoIn();
        batchPersonalNameGeoIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).usRaceEthnicityFullBatch(
                batchPersonalNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#usRaceEthnicityFullBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
