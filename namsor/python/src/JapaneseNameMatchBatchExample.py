import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_1_name1 = models.FirstLastNameIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstName="Tessai",
        lastName="Tomioka",
    )

    personal_names_1_name2 = models.PersonalNameIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c43",
        name="富岡 鉄斎",
    )

    personal_names_1 = models.MatchPersonalFirstLastNameIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c41",
        name1=personal_names_1_name1,
        name2=personal_names_1_name2,
    )

    personal_names = [
        personal_names_1,
    ]

    batch_match_personal_first_last_name_in = models.BatchMatchPersonalFirstLastNameIn(
        personalNames=personal_names,
    )

    try:
        response = api.JapaneseApi(api_client).japanese_name_match_batch(
            batch_match_personal_first_last_name_in=batch_match_personal_first_last_name_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#japanese_name_match_batch: %s\n" % e)
