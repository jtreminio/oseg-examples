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

public class PhoneCodeBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("api_key")).setApiKey("YOUR_API_KEY");

        var personalNamesWithPhoneNumbers1 = new FirstLastNamePhoneNumberIn();
        personalNamesWithPhoneNumbers1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        personalNamesWithPhoneNumbers1.firstName("Jamini");
        personalNamesWithPhoneNumbers1.lastName("Roy");
        personalNamesWithPhoneNumbers1.phoneNumber("09804201420");

        var personalNamesWithPhoneNumbers = new ArrayList<FirstLastNamePhoneNumberIn>(List.of (
            personalNamesWithPhoneNumbers1
        ));

        var batchFirstLastNamePhoneNumberIn = new BatchFirstLastNamePhoneNumberIn();
        batchFirstLastNamePhoneNumberIn.personalNamesWithPhoneNumbers(personalNamesWithPhoneNumbers);

        try
        {
            var response = new SocialApi(config).phoneCodeBatch(
                batchFirstLastNamePhoneNumberIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling SocialApi#phoneCodeBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
