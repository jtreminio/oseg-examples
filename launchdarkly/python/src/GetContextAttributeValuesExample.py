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
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            attribute_name="attributeName_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContextsApi#get_context_attribute_values: %s\n" % e)
