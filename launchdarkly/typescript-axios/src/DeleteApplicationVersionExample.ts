import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ApplicationsBetaApi(configuration).deleteApplicationVersion(
  "applicationKey_string", // applicationKey
  "versionKey_string", // versionKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#deleteApplicationVersion:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
