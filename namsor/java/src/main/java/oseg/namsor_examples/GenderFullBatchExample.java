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

public class GenderFullBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new PersonalNameIn();
        personalNames1.id("0f472330-11a9-49ad-a0f5-bcac90a3f6bf");
        personalNames1.name("Keith Haring");

        var personalNames = new ArrayList<PersonalNameIn>(List.of (
            personalNames1
        ));

        var batchPersonalNameIn = new BatchPersonalNameIn();
        batchPersonalNameIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).genderFullBatch(
                batchPersonalNameIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#genderFullBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
