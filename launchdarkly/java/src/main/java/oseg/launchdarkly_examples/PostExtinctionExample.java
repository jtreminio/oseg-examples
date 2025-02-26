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

public class PostExtinctionExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var extinction1 = new Extinction();
        extinction1.revision("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3");
        extinction1.message("Remove flag for launched feature");
        extinction1.time(1706701522000L);
        extinction1.flagKey("enable-feature");
        extinction1.projKey("default");

        var extinction = new ArrayList<Extinction>(List.of (
            extinction1
        ));

        try
        {
            new CodeReferencesApi(config).postExtinction(
                null, // repo
                null, // branch
                extinction
            );
        } catch (ApiException e) {
            System.err.println("Exception when calling CodeReferencesApi#postExtinction");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
