import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsBetaApi();
apiCaller.setApiKey(api.MetricsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getMetricGroups(
  undefined, // projectKey
  undefined, // filter
  undefined, // expand
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsBetaApi#getMetricGroups:");
  console.log(error.body);
});
