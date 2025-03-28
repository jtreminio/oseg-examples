import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.EnvironmentsApi(configuration).getEnvironmentsByProject(
  "projectKey_string", // projectKey
  undefined, // limit
  undefined, // offset
  undefined, // filter
  undefined, // sort
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling EnvironmentsApi#getEnvironmentsByProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
