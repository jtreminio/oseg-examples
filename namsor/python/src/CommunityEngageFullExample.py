import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PersonalApi(api_client).community_engage_full(
            country_iso2="GB",
            personal_name_full="Ada Lovelace",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#community_engage_full: %s\n" % e)
