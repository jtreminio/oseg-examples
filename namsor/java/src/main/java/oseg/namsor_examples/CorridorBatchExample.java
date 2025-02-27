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

public class CorridorBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var corridorFromTo1FirstLastNameGeoFrom = new FirstLastNameGeoIn();
        corridorFromTo1FirstLastNameGeoFrom.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        corridorFromTo1FirstLastNameGeoFrom.firstName("Ada");
        corridorFromTo1FirstLastNameGeoFrom.lastName("Lovelace");
        corridorFromTo1FirstLastNameGeoFrom.countryIso2("GB");

        var corridorFromTo1FirstLastNameGeoTo = new FirstLastNameGeoIn();
        corridorFromTo1FirstLastNameGeoTo.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        corridorFromTo1FirstLastNameGeoTo.firstName("Nicolas");
        corridorFromTo1FirstLastNameGeoTo.lastName("Tesla");
        corridorFromTo1FirstLastNameGeoTo.countryIso2("US");

        var corridorFromTo1 = new CorridorIn();
        corridorFromTo1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        corridorFromTo1.firstLastNameGeoFrom(corridorFromTo1FirstLastNameGeoFrom);
        corridorFromTo1.firstLastNameGeoTo(corridorFromTo1FirstLastNameGeoTo);

        var corridorFromTo = new ArrayList<CorridorIn>(List.of (
            corridorFromTo1
        ));

        var batchCorridorIn = new BatchCorridorIn();
        batchCorridorIn.corridorFromTo(corridorFromTo);

        try
        {
            var response = new PersonalApi(config).corridorBatch(
                batchCorridorIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#corridorBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
