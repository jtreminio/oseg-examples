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

public class DiasporaFullBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new PersonalNameGeoIn();
        personalNames1.id("0d7d6417-0bbb-4205-951d-b3473f605b56");
        personalNames1.name("Keith Haring");
        personalNames1.countryIso2("US");

        var personalNames = new ArrayList<PersonalNameGeoIn>(List.of (
            personalNames1
        ));

        var batchPersonalNameGeoIn = new BatchPersonalNameGeoIn();
        batchPersonalNameGeoIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).diasporaFullBatch(
                batchPersonalNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#diasporaFullBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
