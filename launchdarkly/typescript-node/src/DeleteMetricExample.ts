import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsApi();
apiCaller.setApiKey(api.MetricsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteMetric(
  undefined, // projectKey
  undefined, // metricKey
).catch(error => {
  console.log("Exception when calling Metrics#deleteMetric:");
  console.log(error.body);
});
