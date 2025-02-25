import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ScheduledChangesApi();
apiCaller.setApiKey(api.ScheduledChangesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFeatureFlagScheduledChange(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ScheduledChanges#getFeatureFlagScheduledChange:");
  console.log(error.body);
});
