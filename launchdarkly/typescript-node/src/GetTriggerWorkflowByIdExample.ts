import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getTriggerWorkflowById(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggers#getTriggerWorkflowById:");
  console.log(error.body);
});
