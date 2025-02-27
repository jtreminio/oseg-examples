import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    mappings_1 = models.InsightsRepositoryProject(
        repositoryKey="launchdarkly/LaunchDarkly-Docs",
        projectKey="default",
    )

    mappings = [
        mappings_1,
    ]

    insights_repository_project_mappings = models.InsightsRepositoryProjectMappings(
        mappings=mappings,
    )

    try:
        response = api.InsightsRepositoriesBetaApi(api_client).associate_repositories_and_projects(
            insights_repository_project_mappings=insights_repository_project_mappings,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsRepositoriesBetaApi#associate_repositories_and_projects: %s\n" % e)
