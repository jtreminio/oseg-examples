import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsScoresBetaApi();
apiCaller.setApiKey(api.InsightsScoresBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteInsightGroup(
  undefined, // insightGroupKey
).catch(error => {
  console.log("Exception when calling InsightsScoresBetaApi#deleteInsightGroup:");
  console.log(error.body);
});
