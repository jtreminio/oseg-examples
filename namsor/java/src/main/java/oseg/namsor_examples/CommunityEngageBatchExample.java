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

public class CommunityEngageBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameGeoIn();
        personalNames1.id("id");
        personalNames1.firstName("firstName");
        personalNames1.lastName("lastName");
        personalNames1.countryIso2("countryIso2");

        var personalNames2 = new FirstLastNameGeoIn();
        personalNames2.id("id");
        personalNames2.firstName("firstName");
        personalNames2.lastName("lastName");
        personalNames2.countryIso2("countryIso2");

        var personalNames = new ArrayList<FirstLastNameGeoIn>(List.of (
            personalNames1,
            personalNames2
        ));

        var batchFirstLastNameGeoIn = new BatchFirstLastNameGeoIn();
        batchFirstLastNameGeoIn.personalNames(personalNames);

        try
        {
            var response = new PersonalApi(config).communityEngageBatch(
                batchFirstLastNameGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling PersonalApi#communityEngageBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
