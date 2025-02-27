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

public class UsRaceEthnicityBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoIn();
        personalNames1.id("85dd5f48-b9e1-4019-88ce-ccc7e56b763f");
        personalNames1.firstName("Keith");
        personalNames1.lastName("Haring");
        personalNames1.countryIso2("US");

        var personalNames = new ArrayList<FirstLastNameGeoIn>(List.of (
            personalNames1
        ));

        var batchFirstLastNameGeoIn = new BatchFirstLastNameGeoIn();
        batchFirstLastNameGeoIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).usRaceEthnicityBatch(
                batchFirstLastNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#usRaceEthnicityBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
