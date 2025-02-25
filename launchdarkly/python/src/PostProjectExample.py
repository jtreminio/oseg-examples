import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    project_post = models.ProjectPost(
        name="My Project",
        key="project-key-123abc",
    )

    try:
        response = api.ProjectsApi(api_client).post_project(
            project_post=project_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Projects#post_project: %s\n" % e)
