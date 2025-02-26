import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExpiringFlagsForUser(
  undefined, // projectKey
  undefined, // userKey
  undefined, // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UserSettingsApi#getExpiringFlagsForUser:");
  console.log(error.body);
});
