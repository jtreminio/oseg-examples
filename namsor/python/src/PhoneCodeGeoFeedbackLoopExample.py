import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.SocialApi(api_client).phone_code_geo_feedback_loop(
            first_name="Teniola",
            last_name="Apata",
            phone_number="08186472651",
            phone_number_e164="",
            country_iso2="NG",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SocialApi#phone_code_geo_feedback_loop: %s\n" % e)
