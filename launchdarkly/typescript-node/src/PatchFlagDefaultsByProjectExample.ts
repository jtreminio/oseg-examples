import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/exampleField",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchFlagDefaultsByProject(
  "projectKey_string", // projectKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ProjectsApi#patchFlagDefaultsByProject:");
  console.log(error.body);
});
