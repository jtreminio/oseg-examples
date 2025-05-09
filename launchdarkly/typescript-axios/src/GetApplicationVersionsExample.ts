import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ApplicationsBetaApi(configuration).getApplicationVersions(
  "applicationKey_string", // applicationKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
  undefined, // sort
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApplicationsBetaApi#getApplicationVersions:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
