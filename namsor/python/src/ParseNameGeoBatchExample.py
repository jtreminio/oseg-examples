import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameGeoIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        name="Ricardo Darín",
        countryIso2="AR",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_personal_name_geo_in = models.BatchPersonalNameGeoIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).parse_name_geo_batch(
            batch_personal_name_geo_in=batch_personal_name_geo_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#parse_name_geo_batch: %s\n" % e)
