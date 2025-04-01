import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.EnvironmentsApi(configuration).resetEnvironmentMobileKey(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling EnvironmentsApi#resetEnvironmentMobileKey:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
