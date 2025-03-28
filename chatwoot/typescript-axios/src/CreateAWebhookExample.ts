import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
  // apiKey: "AGENT_BOT_API_KEY",
  // apiKey: "PLATFORM_APP_API_KEY",
});

const webhookCreateUpdatePayload: api.WebhookCreateUpdatePayload = {
  subscriptions: [
  ],
};

new api.WebhooksApi(configuration).createAWebhook(
  0, // accountId
  webhookCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WebhooksApi#createAWebhook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
