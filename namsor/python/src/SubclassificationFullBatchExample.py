import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameGeoIn(
        id="id",
        name="name",
        countryIso2="countryIso2",
    )

    personal_names_2 = models.PersonalNameGeoIn(
        id="id",
        name="name",
        countryIso2="countryIso2",
    )

    personal_names = [
        personal_names_1,
        personal_names_2,
    ]

    batch_personal_name_geo_in = models.BatchPersonalNameGeoIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).subclassification_full_batch(
            batch_personal_name_geo_in=batch_personal_name_geo_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#subclassification_full_batch: %s\n" % e)
