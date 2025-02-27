import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1 = models.FirstLastNameGenderIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstName="LiYing",
        lastName="Zhao",
        gender="female",
    )

    personal_names = [
        personal_names_1,
    ]

    batch_first_last_name_gender_in = models.BatchFirstLastNameGenderIn(
        personalNames=personal_names,
    )

    try:
        response = api.ChineseApi(api_client).chinese_name_candidates_gender_batch(
            batch_first_last_name_gender_in=batch_first_last_name_gender_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ChineseApi#chinese_name_candidates_gender_batch: %s\n" % e)
