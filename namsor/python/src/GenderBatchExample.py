import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameIn(
        id="b590b04c-da23-4f2f-a334-aee384ee420a",
        firstName="Keith",
        lastName="Haring",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_first_last_name_in = models.BatchFirstLastNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).gender_batch(
            batch_first_last_name_in=batch_first_last_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#gender_batch: %s\n" % e)
