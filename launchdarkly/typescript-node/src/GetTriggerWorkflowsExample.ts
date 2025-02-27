import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTriggerWorkflows(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#getTriggerWorkflows:");
  console.log(error.body);
});
