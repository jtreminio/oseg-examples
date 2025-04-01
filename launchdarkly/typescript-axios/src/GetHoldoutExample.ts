import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.HoldoutsBetaApi(configuration).getHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutKey_string", // holdoutKey
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HoldoutsBetaApi#getHoldout:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
