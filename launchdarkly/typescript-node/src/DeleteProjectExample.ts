import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteProject(
  undefined, // projectKey
).catch(error => {
  console.log("Exception when calling ProjectsApi#deleteProject:");
  console.log(error.body);
});
