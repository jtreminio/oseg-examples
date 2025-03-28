import json
from datetime import date, datetime
from pprint import pprint

from openapi_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    access_token="YOUR_ACCESS_TOKEN",
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PetApi(api_client).find_pets_by_status(
            status=[
                "available",
                "pending",
            ],
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PetApi#find_pets_by_status: %s\n" % e)
