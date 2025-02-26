import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsChartsBetaApi();
apiCaller.setApiKey(api.InsightsChartsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getReleaseFrequencyChart(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // hasExperiments
  undefined, // global
  undefined, // groupBy
  new Date("None"), // from
  new Date("None"), // to
  undefined, // bucketType
  undefined, // bucketMs
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsChartsBetaApi#getReleaseFrequencyChart:");
  console.log(error.body);
});
