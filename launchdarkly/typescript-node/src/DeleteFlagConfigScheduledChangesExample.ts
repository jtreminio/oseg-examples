import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ScheduledChangesApi();
apiCaller.setApiKey(api.ScheduledChangesApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFlagConfigScheduledChanges(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).catch(error => {
  console.log("Exception when calling ScheduledChangesApi#deleteFlagConfigScheduledChanges:");
  console.log(error.body);
});
