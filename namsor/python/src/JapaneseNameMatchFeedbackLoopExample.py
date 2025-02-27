import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.JapaneseApi(api_client).japanese_name_match_feedback_loop(
            japanese_surname_latin="Tessai",
            japanese_given_name_latin="Tomioka",
            japanese_name="富岡 鉄斎",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#japanese_name_match_feedback_loop: %s\n" % e)
