import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patchOperation1: api.PatchOperation = {
  op: "replace",
  path: "/on",
};

const patchOperation = [
  patchOperation1,
];

new api.WebhooksApi(configuration).patchWebhook(
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WebhooksApi#patchWebhook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
