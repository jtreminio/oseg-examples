import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExpiringFlagsForUser(
  "projectKey_string", // projectKey
  "userKey_string", // userKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UserSettingsApi#getExpiringFlagsForUser:");
  console.log(error.body);
});
