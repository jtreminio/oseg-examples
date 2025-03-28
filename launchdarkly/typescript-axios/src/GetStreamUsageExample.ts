import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AccountUsageBetaApi(configuration).getStreamUsage(
  "source_string", // source
  undefined, // from
  undefined, // to
  undefined, // tz
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountUsageBetaApi#getStreamUsage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
