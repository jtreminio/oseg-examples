import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.JapaneseApi(api_client).gender_japanese_name_full(
            japanese_name="中松 義郎",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#gender_japanese_name_full: %s\n" % e)
