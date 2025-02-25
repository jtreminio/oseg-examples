import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsScoresBetaApi();
apiCaller.setApiKey(api.InsightsScoresBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const postInsightGroupParams = new models.PostInsightGroupParams();
postInsightGroupParams.name = "Production - All Apps";
postInsightGroupParams.key = "default-production-all-apps";
postInsightGroupParams.projectKey = "default";
postInsightGroupParams.environmentKey = "production";
postInsightGroupParams.applicationKeys = [
  "billing-service",
  "inventory-service",
];

apiCaller.createInsightGroup(
  postInsightGroupParams,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsScoresBeta#createInsightGroup:");
  console.log(error.body);
});
