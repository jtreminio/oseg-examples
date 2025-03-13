import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    environment_post = models.EnvironmentPost(
        name="My Environment",
        key="environment-key-123abc",
        color="DADBEE",
    )

    try:
        response = api.EnvironmentsApi(api_client).post_environment(
            project_key="projectKey_string",
            environment_post=environment_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling EnvironmentsApi#post_environment: %s\n" % e)
