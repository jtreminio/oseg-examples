import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagTriggerInput: models.FlagTriggerInput = {
  comment: "optional comment",
  instructions: [
    {
      "kind": "disableTrigger"
    }
  ],
};

apiCaller.patchTriggerWorkflow(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
  flagTriggerInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#patchTriggerWorkflow:");
  console.log(error.body);
});
