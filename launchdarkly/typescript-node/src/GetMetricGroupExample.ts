import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getMetricGroup(
  "projectKey_string", // projectKey
  "metricGroupKey_string", // metricGroupKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBetaApi#getMetricGroup:");
  console.log(error.body);
});
