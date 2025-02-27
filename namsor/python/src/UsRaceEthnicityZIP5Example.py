import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.PersonalApi(api_client).us_race_ethnicity_zip5(
            first_name="Keith",
            last_name="Haring",
            zip5_code="12345",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling PersonalApi#us_race_ethnicity_zip5: %s\n" % e)
