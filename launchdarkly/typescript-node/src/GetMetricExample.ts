import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsApi();
apiCaller.setApiKey(api.MetricsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getMetric(
  undefined, // projectKey
  undefined, // metricKey
  undefined, // expand
  undefined, // versionId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsApi#getMetric:");
  console.log(error.body);
});
