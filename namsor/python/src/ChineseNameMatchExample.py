import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ChineseApi(api_client).chinese_name_match(
            chinese_surname_latin="Yu",
            chinese_given_name_latin="Hong",
            chinese_name="喻红",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ChineseApi#chinese_name_match: %s\n" % e)
