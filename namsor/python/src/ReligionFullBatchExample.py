import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameGeoSubdivisionIn(
        id="id",
        name="name",
        countryIso2="countryIso2",
        subdivisionIso="subdivisionIso",
    )

    personal_names_2 = models.PersonalNameGeoSubdivisionIn(
        id="id",
        name="name",
        countryIso2="countryIso2",
        subdivisionIso="subdivisionIso",
    )

    personal_names = [
        personal_names_1,
        personal_names_2,
    ]

    batch_personal_name_geo_subdivision_in = models.BatchPersonalNameGeoSubdivisionIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).religion_full_batch(
            batch_personal_name_geo_subdivision_in=batch_personal_name_geo_subdivision_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#religion_full_batch: %s\n" % e)
