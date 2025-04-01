import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ApplicationsBetaApi(configuration).deleteApplication(
  "applicationKey_string", // applicationKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#deleteApplication:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
