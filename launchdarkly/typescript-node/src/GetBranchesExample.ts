import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getBranches(
  "repo_string", // repo
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CodeReferencesApi#getBranches:");
  console.log(error.body);
});
