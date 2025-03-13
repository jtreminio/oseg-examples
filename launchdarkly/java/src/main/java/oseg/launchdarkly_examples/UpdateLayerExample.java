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

public class UpdateLayerExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        ((ApiKeyAuth) config.getAuthentication("ApiKey")).setApiKey("YOUR_API_KEY");

        var layerPatchInput = new LayerPatchInput();
        layerPatchInput.instructions(JSON.deserialize("""
            [
                {
                    "experimentKey": "checkout-button-color",
                    "kind": "updateExperimentReservation",
                    "reservationPercent": 25
                }
            ]
        """, List.class));
        layerPatchInput.comment("Example comment describing the update");
        layerPatchInput.environmentKey("production");

        try
        {
            var response = new LayersApi(config).updateLayer(
                "projectKey_string", // projectKey
                "layerKey_string", // layerKey
                layerPatchInput
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling LayersApi#updateLayer");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
