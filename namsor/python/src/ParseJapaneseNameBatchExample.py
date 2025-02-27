import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.PersonalNameIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        name="小島 秀夫",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_personal_name_in = models.BatchPersonalNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.JapaneseApi(api_client).parse_japanese_name_batch(
            batch_personal_name_in=batch_personal_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#parse_japanese_name_batch: %s\n" % e)
