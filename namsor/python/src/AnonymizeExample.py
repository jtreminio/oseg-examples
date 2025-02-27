import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AdminApi(api_client).anonymize(
            source="source",
            anonymized=True,
        )
    except ApiException as e:
        print("Exception when calling AdminApi#anonymize: %s\n" % e)
