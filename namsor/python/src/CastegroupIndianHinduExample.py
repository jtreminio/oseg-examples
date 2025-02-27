import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.IndianApi(api_client).castegroup_indian_hindu(
            sub_division_iso31662="IN-UP",
            first_name="Akash",
            last_name="Sharma",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IndianApi#castegroup_indian_hindu: %s\n" % e)
