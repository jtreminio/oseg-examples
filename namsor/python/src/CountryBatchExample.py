import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameIn(
        id="9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
        name="Keith Haring",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_personal_name_in = models.BatchPersonalNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.PersonalApi(api_client).country_batch(
            batch_personal_name_in=batch_personal_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#country_batch: %s\n" % e)
