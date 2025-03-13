import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsDeploymentsBetaApi();
apiCaller.setApiKey(api.InsightsDeploymentsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDeployments(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
  undefined, // limit
  undefined, // expand
  undefined, // from
  undefined, // to
  undefined, // after
  undefined, // before
  undefined, // kind
  undefined, // status
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#getDeployments:");
  console.log(error.body);
});
