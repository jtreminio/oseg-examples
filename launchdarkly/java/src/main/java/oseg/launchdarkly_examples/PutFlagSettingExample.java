package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PutFlagSettingExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var valuePut = new ValuePut();
        valuePut.comment("make sure this context experiences a specific variation");

        try
        {
            new UserSettingsApi(config).putFlagSetting(
                "projectKey_string", // projectKey
                "environmentKey_string", // environmentKey
                "userKey_string", // userKey
                "featureFlagKey_string", // featureFlagKey
                valuePut
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling UserSettingsApi#putFlagSetting");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
