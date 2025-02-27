import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsDeploymentsBetaApi();
apiCaller.setApiKey(api.InsightsDeploymentsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const postDeploymentEventInput = new models.PostDeploymentEventInput();
postDeploymentEventInput.projectKey = "default";
postDeploymentEventInput.environmentKey = "production";
postDeploymentEventInput.applicationKey = "billing-service";
postDeploymentEventInput.version = "a90a8a2";
postDeploymentEventInput.eventType = models.PostDeploymentEventInput.EventTypeEnum.Started;
postDeploymentEventInput.applicationName = "Billing Service";
postDeploymentEventInput.applicationKind = models.PostDeploymentEventInput.ApplicationKindEnum.Server;
postDeploymentEventInput.versionName = "v1.0.0";
postDeploymentEventInput.eventTime = 1706701522000;
postDeploymentEventInput.eventMetadata =   {
  "buildSystemVersion": "v1.2.3"
};
postDeploymentEventInput.deploymentMetadata =   {
  "buildNumber": "1234"
};

apiCaller.createDeploymentEvent(
  postDeploymentEventInput,
).catch(error => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#createDeploymentEvent:");
  console.log(error.body);
});
