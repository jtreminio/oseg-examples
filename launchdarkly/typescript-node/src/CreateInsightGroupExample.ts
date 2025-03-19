import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsScoresBetaApi();
apiCaller.setApiKey(api.InsightsScoresBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const postInsightGroupParams: models.PostInsightGroupParams = {
  name: "Production - All Apps",
  key: "default-production-all-apps",
  projectKey: "default",
  environmentKey: "production",
  applicationKeys: [
    "billing-service",
    "inventory-service",
  ],
};

apiCaller.createInsightGroup(
  postInsightGroupParams,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsScoresBetaApi#createInsightGroup:");
  console.log(error.body);
});
