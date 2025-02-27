import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    personal_names_with_phone_numbers_1 = models.FirstLastNamePhoneNumberIn(
        id="e630dda5-13b3-42c5-8f1d-648aa8a21c42",
        firstName="Jamini",
        lastName="Roy",
        phoneNumber="09804201420",
    )

    personal_names_with_phone_numbers = [
        personal_names_with_phone_numbers_1,
    ]

    batch_first_last_name_phone_number_in = models.BatchFirstLastNamePhoneNumberIn(
        personalNamesWithPhoneNumbers=personal_names_with_phone_numbers,
    )

    try:
        response = api.SocialApi(api_client).phone_code_batch(
            batch_first_last_name_phone_number_in=batch_first_last_name_phone_number_in,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SocialApi#phone_code_batch: %s\n" % e)
