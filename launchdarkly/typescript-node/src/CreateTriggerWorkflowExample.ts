import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagTriggersApi();
apiCaller.setApiKey(api.FlagTriggersApiApiKeys.ApiKey, "YOUR_API_KEY");

const triggerPost = new models.TriggerPost();
triggerPost.integrationKey = "generic-trigger";
triggerPost.comment = "example comment";
triggerPost.instructions =   [
  {
    "kind": "turnFlagOn"
  }
];

apiCaller.createTriggerWorkflow(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // featureFlagKey
  triggerPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagTriggersApi#createTriggerWorkflow:");
  console.log(error.body);
});
