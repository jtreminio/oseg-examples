import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.WebhooksApi(configuration).getWebhook(
  "id_string", // id
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WebhooksApi#getWebhook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
