import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsDeploymentsBetaApi();
apiCaller.setApiKey(api.InsightsDeploymentsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getDeployment(
  "deploymentID_string", // deploymentID
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsDeploymentsBetaApi#getDeployment:");
  console.log(error.body);
});
