import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteTriggerWorkflow(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
).catch(error => {
  console.log("Exception when calling FlagTriggersApi#deleteTriggerWorkflow:");
  console.log(error.body);
});
