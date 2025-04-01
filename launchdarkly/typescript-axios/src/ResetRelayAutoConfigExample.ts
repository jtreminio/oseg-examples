import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.RelayProxyConfigurationsApi(configuration).resetRelayAutoConfig(
  "id_string", // id
  undefined, // expiry
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling RelayProxyConfigurationsApi#resetRelayAutoConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
