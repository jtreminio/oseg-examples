import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ContextsApi(api_client).get_context_attribute_values(
            project_key=None,
            environment_key=None,
            attribute_name=None,
            filter=None,
            limit=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Contexts#get_context_attribute_values: %s\n" % e)
