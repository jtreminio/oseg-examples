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

public class PhoneCodeGeoBatchExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var personalNamesWithPhoneNumbers1 = new FirstLastNamePhoneNumberGeoIn();
        personalNamesWithPhoneNumbers1.id("e630dda5-13b3-42c5-8f1d-648aa8a21c42");
        personalNamesWithPhoneNumbers1.firstName("Teniola");
        personalNamesWithPhoneNumbers1.lastName("Apata");
        personalNamesWithPhoneNumbers1.phoneNumber("08186472651");
        personalNamesWithPhoneNumbers1.countryIso2("NG");
        personalNamesWithPhoneNumbers1.countryIso2Alt("CI");

        var personalNamesWithPhoneNumbers = new ArrayList<FirstLastNamePhoneNumberGeoIn>(List.of (
            personalNamesWithPhoneNumbers1
        ));

        var batchFirstLastNamePhoneNumberGeoIn = new BatchFirstLastNamePhoneNumberGeoIn();
        batchFirstLastNamePhoneNumberGeoIn.personalNamesWithPhoneNumbers(personalNamesWithPhoneNumbers);

        try
        {
            var response = new SocialApi(config).phoneCodeGeoBatch(
                batchFirstLastNamePhoneNumberGeoIn
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling SocialApi#phoneCodeGeoBatch");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
