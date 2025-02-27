import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameGeoZippedIn(
        id="728767f9-c5b2-4ed3-a071-828077f16552",
        firstName="Keith",
        lastName="Haring",
        countryIso2="US",
        zipCode="10019",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_first_last_name_geo_zipped_in = models.BatchFirstLastNameGeoZippedIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).us_zip_race_ethnicity_batch(
            batch_first_last_name_geo_zipped_in=batch_first_last_name_geo_zipped_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#us_zip_race_ethnicity_batch: %s\n" % e)
