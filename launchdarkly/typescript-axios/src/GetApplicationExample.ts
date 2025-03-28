import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ApplicationsBetaApi(configuration).getApplication(
  "applicationKey_string", // applicationKey
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#getApplication:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
