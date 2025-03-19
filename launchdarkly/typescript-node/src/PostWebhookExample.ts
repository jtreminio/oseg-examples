import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.ApiKey, "YOUR_API_KEY");

const statements1: models.StatementPost = {
  effect: models.StatementPost.EffectEnum.Allow,
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

const webhookPost: models.WebhookPost = {
  url: "https://example.com",
  sign: false,
  on: true,
  name: "apidocs test webhook",
  tags: [
    "example-tag",
  ],
  statements: statements,
};

apiCaller.postWebhook(
  webhookPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WebhooksApi#postWebhook:");
  console.log(error.body);
});
