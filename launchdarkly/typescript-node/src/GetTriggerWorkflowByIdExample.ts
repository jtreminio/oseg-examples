import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTriggerWorkflowById(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#getTriggerWorkflowById:");
  console.log(error.body);
});
