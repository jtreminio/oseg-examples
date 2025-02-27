import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.JapaneseApi(api_client).japanese_name_latin_candidates(
            japanese_surname_kanji="塩田",
            japanese_given_name_kanji="千春",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#japanese_name_latin_candidates: %s\n" % e)
