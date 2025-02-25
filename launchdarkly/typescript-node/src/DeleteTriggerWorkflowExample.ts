import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteTriggerWorkflow(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // featureFlagKey
  undefined, // id
).catch(error => {
  console.log("Exception when calling FlagTriggers#deleteTriggerWorkflow:");
  console.log(error.body);
});
