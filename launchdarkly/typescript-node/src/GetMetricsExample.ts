import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.MetricsApi();
apiCaller.setApiKey(api.MetricsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getMetrics(
  "projectKey_string", // projectKey
  undefined, // expand
  undefined, // limit
  undefined, // offset
  undefined, // sort
  undefined, // filter
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling MetricsApi#getMetrics:");
  console.log(error.body);
});
