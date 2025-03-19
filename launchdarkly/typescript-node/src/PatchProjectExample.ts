import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "add",
  path: "/tags/0",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.patchProject(
  "projectKey_string", // projectKey
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ProjectsApi#patchProject:");
  console.log(error.body);
});
