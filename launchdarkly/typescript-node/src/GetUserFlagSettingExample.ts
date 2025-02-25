import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getUserFlagSetting(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // userKey
  undefined, // featureFlagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UserSettings#getUserFlagSetting:");
  console.log(error.body);
});
