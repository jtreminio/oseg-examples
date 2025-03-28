import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.MetricsApi(configuration).getMetrics(
  "projectKey_string", // projectKey
  undefined, // expand
  undefined, // limit
  undefined, // offset
  undefined, // sort
  undefined, // filter
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling MetricsApi#getMetrics:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
