import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ScheduledChangesApi();
apiCaller.setApiKey(api.ScheduledChangesApiApiKeys.ApiKey, "YOUR_API_KEY");

const postFlagScheduledChangesInput = new models.PostFlagScheduledChangesInput();
postFlagScheduledChangesInput.executionDate = 1718467200000;
postFlagScheduledChangesInput.instructions =   [
  {
    "kind": "turnFlagOn"
  }
];
postFlagScheduledChangesInput.comment = "Optional comment describing the scheduled changes";

apiCaller.postFlagConfigScheduledChanges(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  postFlagScheduledChangesInput,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ScheduledChanges#postFlagConfigScheduledChanges:");
  console.log(error.body);
});
