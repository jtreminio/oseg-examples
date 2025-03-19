import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    context_search = models.ContextSearch(
        filter="*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]",
        sort="-ts",
        limit=10,
        continuationToken="QAGFKH1313KUGI2351",
    )

    try:
        response = api.ContextsApi(api_client).search_contexts(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            context_search=context_search,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContextsApi#search_contexts: %s\n" % e)
