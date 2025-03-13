import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/requireComments";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchEnvironment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling EnvironmentsApi#patchEnvironment:");
  console.log(error.body);
});
