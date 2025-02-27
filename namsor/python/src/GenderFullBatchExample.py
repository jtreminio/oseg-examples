import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameIn(
        id="0f472330-11a9-49ad-a0f5-bcac90a3f6bf",
        name="Keith Haring",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_personal_name_in = models.BatchPersonalNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).gender_full_batch(
            batch_personal_name_in=batch_personal_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#gender_full_batch: %s\n" % e)
