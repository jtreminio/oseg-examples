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

public class ChineseNameCandidatesBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameIn();
        personalNames1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        personalNames1.firstName("LiYing");
        personalNames1.lastName("Zhao");

        var personalNames = new ArrayList<FirstLastNameIn>(List.of (
            personalNames1
        ));

        var batchFirstLastNameIn = new BatchFirstLastNameIn();
        batchFirstLastNameIn.personalNames(personalNames);

        try
        {
            var response = new ChineseApi(config).chineseNameCandidatesBatch(
                batchFirstLastNameIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling ChineseApi#chineseNameCandidatesBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
