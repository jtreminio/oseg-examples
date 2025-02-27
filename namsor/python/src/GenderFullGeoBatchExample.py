import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameGeoIn(
        id="3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f",
        name="Keith Haring",
        countryIso2="US",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_personal_name_geo_in = models.BatchPersonalNameGeoIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).gender_full_geo_batch(
            batch_personal_name_geo_in=batch_personal_name_geo_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#gender_full_geo_batch: %s\n" % e)
