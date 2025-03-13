import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsScoresBetaApi();
apiCaller.setApiKey(api.InsightsScoresBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getInsightsScores(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsScoresBetaApi#getInsightsScores:");
  console.log(error.body);
});
