import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ChineseApi(api_client).parse_chinese_name(
            chinese_name="赵丽颖",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ChineseApi#parse_chinese_name: %s\n" % e)
