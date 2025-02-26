import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteBranches(
  undefined, // repo
  [
    "branch-to-be-deleted",
    "another-branch-to-be-deleted",
  ], // requestBody
).catch(error => {
  console.log("Exception when calling CodeReferencesApi#deleteBranches:");
  console.log(error.body);
});
