import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PersonalApi(api_client).gender_full(
            full_name="Keith Haring",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#gender_full: %s\n" % e)
