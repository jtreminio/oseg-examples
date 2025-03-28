import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const valuePut: api.ValuePut = {
  comment: "make sure this context experiences a specific variation",
};

new api.ContextSettingsApi(configuration).putContextFlagSetting(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "contextKind_string", // contextKind
  "contextKey_string", // contextKey
  "featureFlagKey_string", // featureFlagKey
  valuePut,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextSettingsApi#putContextFlagSetting:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
