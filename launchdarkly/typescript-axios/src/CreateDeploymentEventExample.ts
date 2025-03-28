import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const postDeploymentEventInput: api.PostDeploymentEventInput = {
  projectKey: "default",
  environmentKey: "production",
  applicationKey: "billing-service",
  version: "a90a8a2",
  eventType: api.PostDeploymentEventInputEventTypeEnum.Started,
  applicationName: "Billing Service",
  applicationKind: api.PostDeploymentEventInputApplicationKindEnum.Server,
  versionName: "v1.0.0",
  eventTime: 1706701522000,
  eventMetadata: {
    "buildSystemVersion": "v1.2.3"
  },
  deploymentMetadata: {
    "buildNumber": "1234"
  },
};

new api.InsightsDeploymentsBetaApi(configuration).createDeploymentEvent(
  postDeploymentEventInput,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#createDeploymentEvent:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
