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

public class PutContextFlagSettingExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var valuePut = new ValuePut();
        valuePut.comment("make sure this context experiences a specific variation");

        try
        {
            new ContextSettingsApi(config).putContextFlagSetting(
                null, // projectKey
                null, // environmentKey
                null, // contextKind
                null, // contextKey
                null, // featureFlagKey
                valuePut
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling ContextSettings#putContextFlagSetting");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
