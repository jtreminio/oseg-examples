import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameIn(
        id="id",
        firstName="firstName",
        lastName="lastName",
    )

    personal_names_2 = models.FirstLastNameIn(
        id="id",
        firstName="firstName",
        lastName="lastName",
    )

    personal_names = [
        personal_names_1,
        personal_names_2,
    ]

    batch_first_last_name_in = models.BatchFirstLastNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.JapaneseApi(api_client).gender_japanese_name_pinyin_batch(
            batch_first_last_name_in=batch_first_last_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#gender_japanese_name_pinyin_batch: %s\n" % e)
