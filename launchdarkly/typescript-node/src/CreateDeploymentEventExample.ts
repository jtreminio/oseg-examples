import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsDeploymentsBetaApi();
apiCaller.setApiKey(api.InsightsDeploymentsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const postDeploymentEventInput: models.PostDeploymentEventInput = {
  projectKey: "default",
  environmentKey: "production",
  applicationKey: "billing-service",
  version: "a90a8a2",
  eventType: models.PostDeploymentEventInput.EventTypeEnum.Started,
  applicationName: "Billing Service",
  applicationKind: models.PostDeploymentEventInput.ApplicationKindEnum.Server,
  versionName: "v1.0.0",
  eventTime: 1706701522000,
  eventMetadata: {
    "buildSystemVersion": "v1.2.3"
  },
  deploymentMetadata: {
    "buildNumber": "1234"
  },
};

apiCaller.createDeploymentEvent(
  postDeploymentEventInput,
).catch(error => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#createDeploymentEvent:");
  console.log(error.body);
});
