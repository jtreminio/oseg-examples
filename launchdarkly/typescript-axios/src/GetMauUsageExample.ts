import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.AccountUsageBetaApi(configuration).getMauUsage().then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AccountUsageBetaApi#getMauUsage:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
