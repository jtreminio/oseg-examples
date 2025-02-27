import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.ApiKey, "YOUR_API_KEY");

const statements1 = new models.StatementPost();
statements1.effect = models.StatementPost.EffectEnum.Allow;
statements1.resources = [
  "proj/test",
];
statements1.actions = [
  "*",
];

const statements = [
  statements1,
];

const webhookPost = new models.WebhookPost();
webhookPost.url = "https://example.com";
webhookPost.sign = false;
webhookPost.on = true;
webhookPost.name = "apidocs test webhook";
webhookPost.tags = [
  "example-tag",
];
webhookPost.statements = statements;

apiCaller.postWebhook(
  webhookPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WebhooksApi#postWebhook:");
  console.log(error.body);
});
