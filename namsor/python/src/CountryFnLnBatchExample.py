import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameIn(
        id="9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4",
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
        response = api.PersonalApi(api_client).country_fn_ln_batch(
            batch_first_last_name_in=batch_first_last_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#country_fn_ln_batch: %s\n" % e)
