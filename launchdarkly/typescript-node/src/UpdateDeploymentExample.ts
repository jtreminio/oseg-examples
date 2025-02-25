import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsDeploymentsBetaApi();
apiCaller.setApiKey(api.InsightsDeploymentsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/status";

const patchOperation = [
  patchOperation1,
];

apiCaller.updateDeployment(
  undefined, // deploymentID
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsDeploymentsBeta#updateDeployment:");
  console.log(error.body);
});
