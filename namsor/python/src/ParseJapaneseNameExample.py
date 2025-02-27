import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.JapaneseApi(api_client).parse_japanese_name(
            japanese_name="小島 秀夫",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling JapaneseApi#parse_japanese_name: %s\n" % e)
