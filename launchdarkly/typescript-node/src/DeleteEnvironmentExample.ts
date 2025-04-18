import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteEnvironment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).catch(error => {
  console.log("Exception when calling EnvironmentsApi#deleteEnvironment:");
  console.log(error.body);
});
