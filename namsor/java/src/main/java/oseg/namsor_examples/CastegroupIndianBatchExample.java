package oseg.namsor_examples;

import app.namsor.client.ApiException;
import app.namsor.client.Configuration;
import app.namsor.client.api.*;
import app.namsor.client.auth.*;
import app.namsor.client.JSON;
import app.namsor.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class CastegroupIndianBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameSubdivisionIn();
        personalNames1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        personalNames1.firstName("Akash");
        personalNames1.lastName("Sharma");
        personalNames1.subdivisionIso("IN-UP");

        var personalNames = new ArrayList<FirstLastNameSubdivisionIn>(List.of (
            personalNames1
        ));

        var batchFirstLastNameSubdivisionIn = new BatchFirstLastNameSubdivisionIn();
        batchFirstLastNameSubdivisionIn.personalNames(personalNames);

        try
        {
            var response = new IndianApi(config).castegroupIndianBatch(
                batchFirstLastNameSubdivisionIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling IndianApi#castegroupIndianBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
