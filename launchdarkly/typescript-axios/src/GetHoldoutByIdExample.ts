import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.HoldoutsBetaApi(configuration).getHoldoutById(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutId_string", // holdoutId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HoldoutsBetaApi#getHoldoutById:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
