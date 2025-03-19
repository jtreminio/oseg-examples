import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ScheduledChangesApi();
apiCaller.setApiKey(api.ScheduledChangesApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagScheduledChangesInput: models.FlagScheduledChangesInput = {
  instructions: [
    {
      "kind": "replaceScheduledChangesInstructions",
      "value": [
        {
          "kind": "turnFlagOff"
        }
      ]
    }
  ],
  comment: "Optional comment describing the update to the scheduled changes",
};

apiCaller.patchFlagConfigScheduledChange(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  flagScheduledChangesInput,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ScheduledChangesApi#patchFlagConfigScheduledChange:");
  console.log(error.body);
});
