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

public class NameTypeGeoBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var properNouns1 = new NameGeoIn();
        properNouns1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        properNouns1.name("Edi Gathegi");
        properNouns1.countryIso2("KE");

        var properNouns = new ArrayList<NameGeoIn>(List.of (
            properNouns1
        ));

        var batchNameGeoIn = new BatchNameGeoIn();
        batchNameGeoIn.properNouns(properNouns);

        try
        {
            var response = new GeneralApi(config).nameTypeGeoBatch(
                batchNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling GeneralApi#nameTypeGeoBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
