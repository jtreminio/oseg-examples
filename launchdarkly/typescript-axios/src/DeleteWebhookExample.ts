import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.WebhooksApi(configuration).deleteWebhook(
  "id_string", // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WebhooksApi#deleteWebhook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
