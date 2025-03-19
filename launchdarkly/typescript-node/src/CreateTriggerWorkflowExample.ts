import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

const triggerPost: models.TriggerPost = {
  integrationKey: "generic-trigger",
  comment: "example comment",
  instructions: [
    {
      "kind": "turnFlagOn"
    }
  ],
};

apiCaller.createTriggerWorkflow(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  triggerPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#createTriggerWorkflow:");
  console.log(error.body);
});
