import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteRepository(
  "repo_string", // repo
).catch(error => {
  console.log("Exception when calling CodeReferencesApi#deleteRepository:");
  console.log(error.body);
});
