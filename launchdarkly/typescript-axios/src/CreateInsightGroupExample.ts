import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const postInsightGroupParams: api.PostInsightGroupParams = {
  name: "Production - All Apps",
  key: "default-production-all-apps",
  projectKey: "default",
  environmentKey: "production",
  applicationKeys: [
    "billing-service",
    "inventory-service",
  ],
};

new api.InsightsScoresBetaApi(configuration).createInsightGroup(
  postInsightGroupParams,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsScoresBetaApi#createInsightGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
