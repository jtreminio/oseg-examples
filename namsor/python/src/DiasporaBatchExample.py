import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameGeoIn(
        id="0d7d6417-0bbb-4205-951d-b3473f605b56",
        firstName="Keith",
        lastName="Haring",
        countryIso2="US",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_first_last_name_geo_in = models.BatchFirstLastNameGeoIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).diaspora_batch(
            batch_first_last_name_geo_in=batch_first_last_name_geo_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#diaspora_batch: %s\n" % e)
