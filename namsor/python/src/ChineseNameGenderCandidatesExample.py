import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ChineseApi(api_client).chinese_name_gender_candidates(
            chinese_surname_latin="Hong",
            chinese_given_name_latin="Yu",
            known_gender="m",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ChineseApi#chinese_name_gender_candidates: %s\n" % e)
