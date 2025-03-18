import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsChartsBetaApi();
apiCaller.setApiKey(api.InsightsChartsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getLeadTimeChart(
  "projectKey_string", // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // from
  undefined, // to
  undefined, // bucketType
  undefined, // bucketMs
  undefined, // groupBy
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsChartsBetaApi#getLeadTimeChart:");
  console.log(error.body);
});
