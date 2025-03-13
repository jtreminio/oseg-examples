import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

const valuePut = new models.ValuePut();
valuePut.comment = "make sure this context experiences a specific variation";

apiCaller.putFlagSetting(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
  "featureFlagKey_string", // featureFlagKey
  valuePut,
).catch(error => {
  console.log("Exception when calling UserSettingsApi#putFlagSetting:");
  console.log(error.body);
});
