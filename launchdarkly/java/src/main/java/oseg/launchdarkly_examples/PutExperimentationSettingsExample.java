package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PutExperimentationSettingsExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var randomizationUnits1 = new RandomizationUnitInput();
        randomizationUnits1.randomizationUnit("user");
        randomizationUnits1.standardRandomizationUnit(RandomizationUnitInput.StandardRandomizationUnitEnum.ORGANIZATION);

        var randomizationUnits = new ArrayList<RandomizationUnitInput>(List.of (
            randomizationUnits1
        ));

        var randomizationSettingsPut = new RandomizationSettingsPut();
        randomizationSettingsPut.randomizationUnits(randomizationUnits);

        try
        {
            var response = new ExperimentsApi(config).putExperimentationSettings(
                "the-project-key", // projectKey
                randomizationSettingsPut
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling Experiments#putExperimentationSettings");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
