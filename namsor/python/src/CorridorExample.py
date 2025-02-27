import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PersonalApi(api_client).corridor(
            country_iso2_from="GB",
            first_name_from="Ada",
            last_name_from="Lovelace",
            country_iso2_to="US",
            first_name_to="Nicolas",
            last_name_to="Tesla",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#corridor: %s\n" % e)
