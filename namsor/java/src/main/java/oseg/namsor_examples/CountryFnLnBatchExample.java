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

public class CountryFnLnBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameIn();
        personalNames1.id("9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4");
        personalNames1.firstName("Keith");
        personalNames1.lastName("Haring");

        var personalNames = new ArrayList<FirstLastNameIn>(List.of (
            personalNames1
        ));

        var batchFirstLastNameIn = new BatchFirstLastNameIn();
        batchFirstLastNameIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).countryFnLnBatch(
                batchFirstLastNameIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#countryFnLnBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
