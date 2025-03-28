import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.LayersApi(configuration).getLayers(
  "projectKey_string", // projectKey
  undefined, // filter
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling LayersApi#getLayers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
