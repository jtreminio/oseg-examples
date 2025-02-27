import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    post_deployment_event_input = models.PostDeploymentEventInput(
        projectKey="default",
        environmentKey="production",
        applicationKey="billing-service",
        version="a90a8a2",
        eventType="started",
        applicationName="Billing Service",
        applicationKind="server",
        versionName="v1.0.0",
        eventTime=1706701522000,
        eventMetadata=json.loads("""
            {
                "buildSystemVersion": "v1.2.3"
            }
        """),
        deploymentMetadata=json.loads("""
            {
                "buildNumber": "1234"
            }
        """),
    )

    try:
        api.InsightsDeploymentsBetaApi(api_client).create_deployment_event(
            post_deployment_event_input=post_deployment_event_input,
        )
    except ApiException as e:
        print("Exception when calling InsightsDeploymentsBetaApi#create_deployment_event: %s\n" % e)
