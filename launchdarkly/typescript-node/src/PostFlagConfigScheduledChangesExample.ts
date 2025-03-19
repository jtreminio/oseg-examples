import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ScheduledChangesApi();
apiCaller.setApiKey(api.ScheduledChangesApiApiKeys.ApiKey, "YOUR_API_KEY");

const postFlagScheduledChangesInput: models.PostFlagScheduledChangesInput = {
  executionDate: 1718467200000,
  instructions: [
    {
      "kind": "turnFlagOn"
    }
  ],
  comment: "Optional comment describing the scheduled changes",
};

apiCaller.postFlagConfigScheduledChanges(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  postFlagScheduledChangesInput,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ScheduledChangesApi#postFlagConfigScheduledChanges:");
  console.log(error.body);
});
