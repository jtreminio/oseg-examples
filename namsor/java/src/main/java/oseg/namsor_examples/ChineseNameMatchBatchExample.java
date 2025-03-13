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

public class ChineseNameMatchBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1Name1 = new FirstLastNameIn();
        personalNames1Name1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        personalNames1Name1.firstName("Hong");
        personalNames1Name1.lastName("Yu");

        var personalNames1Name2 = new PersonalNameIn();
        personalNames1Name2.id("e630dda5-13b3-42c5-8f1d-648aa8a21c43");
        personalNames1Name2.name("喻红");

        var personalNames1 = new MatchPersonalFirstLastNameIn();
        personalNames1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c41");
        personalNames1.name1(personalNames1Name1);
        personalNames1.name2(personalNames1Name2);

        var personalNames = new ArrayList<MatchPersonalFirstLastNameIn>(List.of (
            personalNames1
        ));

        var batchMatchPersonalFirstLastNameIn = new BatchMatchPersonalFirstLastNameIn();
        batchMatchPersonalFirstLastNameIn.personalNames(personalNames);

        try
        {
            var response = new ChineseApi(config).chineseNameMatchBatch(
                batchMatchPersonalFirstLastNameIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ChineseApi#chineseNameMatchBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
