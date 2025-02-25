import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    context_instance_search = models.ContextInstanceSearch(
        filter="{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}",
        sort="-ts",
        limit=10,
        continuationToken="QAGFKH1313KUGI2351",
    )

    try:
        response = api.ContextsApi(api_client).search_context_instances(
            project_key=None,
            environment_key=None,
            context_instance_search=context_instance_search,
            limit=None,
            continuation_token=None,
            sort=None,
            filter=None,
            include_total_count=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Contexts#search_context_instances: %s\n" % e)
