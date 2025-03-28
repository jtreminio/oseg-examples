import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const valuePut: api.ValuePut = {
  comment: "make sure this context experiences a specific variation",
};

new api.UserSettingsApi(configuration).putFlagSetting(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
  "featureFlagKey_string", // featureFlagKey
  valuePut,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserSettingsApi#putFlagSetting:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
