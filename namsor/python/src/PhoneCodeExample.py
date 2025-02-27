import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.SocialApi(api_client).phone_code(
            first_name="Jamini",
            last_name="Roy",
            phone_number="09804201420",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SocialApi#phone_code: %s\n" % e)
