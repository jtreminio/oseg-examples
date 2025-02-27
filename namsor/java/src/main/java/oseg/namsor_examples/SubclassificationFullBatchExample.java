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

public class SubclassificationFullBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var personalNames1 = new PersonalNameGeoIn();
        personalNames1.id("id");
        personalNames1.name("name");
        personalNames1.countryIso2("countryIso2");

        var personalNames2 = new PersonalNameGeoIn();
        personalNames2.id("id");
        personalNames2.name("name");
        personalNames2.countryIso2("countryIso2");

        var personalNames = new ArrayList<PersonalNameGeoIn>(List.of (
            personalNames1,
            personalNames2
        ));

        var batchPersonalNameGeoIn = new BatchPersonalNameGeoIn();
        batchPersonalNameGeoIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).subclassificationFullBatch(
                batchPersonalNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#subclassificationFullBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
