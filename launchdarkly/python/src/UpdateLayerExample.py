import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    layer_patch_input = models.LayerPatchInput(
        instructions=json.loads("""
            [
                {
                    "experimentKey": "checkout-button-color",
                    "kind": "updateExperimentReservation",
                    "reservationPercent": 25
                }
            ]
        """),
        comment="Example comment describing the update",
        environmentKey="production",
    )

    try:
        response = api.LayersApi(api_client).update_layer(
            project_key=None,
            layer_key=None,
            layer_patch_input=layer_patch_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling LayersApi#update_layer: %s\n" % e)
