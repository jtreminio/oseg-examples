import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    layer_post = models.LayerPost(
        key="checkout-flow",
        name="Checkout Flow",
        description=None,
    )

    try:
        response = api.LayersApi(api_client).create_layer(
            project_key=None,
            layer_post=layer_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Layers#create_layer: %s\n" % e)
