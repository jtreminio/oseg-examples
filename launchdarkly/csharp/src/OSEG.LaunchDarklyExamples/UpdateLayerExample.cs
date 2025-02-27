using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class UpdateLayerExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var layerPatchInput = new LayerPatchInput(
            instructions: JsonSerializer.Deserialize<List<Dictionary<string, object>>>("""
                [
                    {
                        "experimentKey": "checkout-button-color",
                        "kind": "updateExperimentReservation",
                        "reservationPercent": 25
                    }
                ]
            """),
            comment: "Example comment describing the update",
            environmentKey: "production"
        );

        try
        {
            var response = new LayersApi(config).UpdateLayer(
                projectKey: null,
                layerKey: null,
                layerPatchInput: layerPatchInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling LayersApi#UpdateLayer: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
