import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteMetricGroup(
  undefined, // projectKey
  undefined, // metricGroupKey
).catch(error => {
  console.log("Exception when calling MetricsBetaApi#deleteMetricGroup:");
  console.log(error.body);
});
