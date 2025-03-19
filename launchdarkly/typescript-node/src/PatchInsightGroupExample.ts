import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsScoresBetaApi();
apiCaller.setApiKey(api.InsightsScoresBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/name",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchInsightGroup(
  "insightGroupKey_string", // insightGroupKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsScoresBetaApi#patchInsightGroup:");
  console.log(error.body);
});
