import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagTriggerInput = new models.FlagTriggerInput();
flagTriggerInput.comment = "optional comment";
flagTriggerInput.instructions = [
  {
    "kind": "disableTrigger"
  }
];

apiCaller.patchTriggerWorkflow(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // featureFlagKey
  undefined, // id
  flagTriggerInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#patchTriggerWorkflow:");
  console.log(error.body);
});
