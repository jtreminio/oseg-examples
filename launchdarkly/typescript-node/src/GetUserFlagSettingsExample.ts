import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getUserFlagSettings(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // userKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UserSettings#getUserFlagSettings:");
  console.log(error.body);
});
