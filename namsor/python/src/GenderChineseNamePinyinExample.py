import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ChineseApi(api_client).gender_chinese_name_pinyin(
            chinese_surname_latin="Dèng",
            chinese_given_name_latin="Qīngyún",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ChineseApi#gender_chinese_name_pinyin: %s\n" % e)
