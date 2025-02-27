import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

const valuePut = new models.ValuePut();
valuePut.comment = "make sure this context experiences a specific variation";

apiCaller.putFlagSetting(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // userKey
  undefined, // featureFlagKey
  valuePut,
).catch(error => {
  console.log("Exception when calling UserSettingsApi#putFlagSetting:");
  console.log(error.body);
});
