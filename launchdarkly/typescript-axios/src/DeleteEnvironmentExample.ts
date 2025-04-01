import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.EnvironmentsApi(configuration).deleteEnvironment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling EnvironmentsApi#deleteEnvironment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
