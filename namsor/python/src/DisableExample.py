import json
from datetime import date, datetime
from pprint import pprint

from namsor_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"api_key": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AdminApi(api_client).disable(
            source="source",
            disabled=True,
        )
    except ApiException as e:
        print("Exception when calling AdminApi#disable: %s\n" % e)
