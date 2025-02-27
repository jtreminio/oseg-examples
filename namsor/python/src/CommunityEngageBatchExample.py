import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameGeoIn(
        id="id",
        firstName="firstName",
        lastName="lastName",
        countryIso2="countryIso2",
    )

    personal_names_2 = models.FirstLastNameGeoIn(
        id="id",
        firstName="firstName",
        lastName="lastName",
        countryIso2="countryIso2",
    )

    personal_names = [
        personal_names_1,
        personal_names_2,
    ]

    batch_first_last_name_geo_in = models.BatchFirstLastNameGeoIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).community_engage_batch(
            batch_first_last_name_geo_in=batch_first_last_name_geo_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#community_engage_batch: %s\n" % e)
