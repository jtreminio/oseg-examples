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

public class GenderJapaneseNamePinyinBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var personalNames1 = new FirstLastNameIn();
        personalNames1.id("id");
        personalNames1.firstName("firstName");
        personalNames1.lastName("lastName");

        var personalNames2 = new FirstLastNameIn();
        personalNames2.id("id");
        personalNames2.firstName("firstName");
        personalNames2.lastName("lastName");

        var personalNames = new ArrayList<FirstLastNameIn>(List.of (
            personalNames1,
            personalNames2
        ));

        var batchFirstLastNameIn = new BatchFirstLastNameIn();
        batchFirstLastNameIn.personalNames(personalNames);

        try
        {
            var response = new JapaneseApi(config).genderJapaneseNamePinyinBatch(
                batchFirstLastNameIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling JapaneseApi#genderJapaneseNamePinyinBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
