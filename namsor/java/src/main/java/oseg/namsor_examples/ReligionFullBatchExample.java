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

public class ReligionFullBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new PersonalNameGeoSubdivisionIn();
        personalNames1.id("id");
        personalNames1.name("name");
        personalNames1.countryIso2("countryIso2");
        personalNames1.subdivisionIso("subdivisionIso");

        var personalNames2 = new PersonalNameGeoSubdivisionIn();
        personalNames2.id("id");
        personalNames2.name("name");
        personalNames2.countryIso2("countryIso2");
        personalNames2.subdivisionIso("subdivisionIso");

        var personalNames = new ArrayList<PersonalNameGeoSubdivisionIn>(List.of (
            personalNames1,
            personalNames2
        ));

        var batchPersonalNameGeoSubdivisionIn = new BatchPersonalNameGeoSubdivisionIn();
        batchPersonalNameGeoSubdivisionIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).religionFullBatch(
                batchPersonalNameGeoSubdivisionIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#religionFullBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
