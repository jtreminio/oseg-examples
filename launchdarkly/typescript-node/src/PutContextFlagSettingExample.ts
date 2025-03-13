import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextSettingsApi();
apiCaller.setApiKey(api.ContextSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

const valuePut = new models.ValuePut();
valuePut.comment = "make sure this context experiences a specific variation";

apiCaller.putContextFlagSetting(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "contextKind_string", // contextKind
  "contextKey_string", // contextKey
  "featureFlagKey_string", // featureFlagKey
  valuePut,
).catch(error => {
  console.log("Exception when calling ContextSettingsApi#putContextFlagSetting:");
  console.log(error.body);
});
