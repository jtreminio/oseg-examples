import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const statements1: api.StatementPost = {
  effect: api.StatementPostEffectEnum.Allow,
  resources: [
    "proj/test",
  ],
  actions: [
    "*",
  ],
};

const statements = [
  statements1,
];

const webhookPost: api.WebhookPost = {
  url: "https://example.com",
  sign: false,
  on: true,
  name: "apidocs test webhook",
  tags: [
    "example-tag",
  ],
  statements: statements,
};

new api.WebhooksApi(configuration).postWebhook(
  webhookPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling WebhooksApi#postWebhook:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
