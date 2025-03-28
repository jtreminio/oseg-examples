import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UsersBetaApi(configuration).getUserAttributeNames(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UsersBetaApi#getUserAttributeNames:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
