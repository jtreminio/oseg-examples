import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsChartsBetaApi();
apiCaller.setApiKey(api.InsightsChartsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFlagStatusChart(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsChartsBetaApi#getFlagStatusChart:");
  console.log(error.body);
});
