import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.WebhooksApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.WebhooksApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const webhookCreateUpdatePayload = new models.WebhookCreateUpdatePayload();
webhookCreateUpdatePayload.url = undefined;
webhookCreateUpdatePayload.subscriptions = [
];

apiCaller.createAWebhook(
  undefined, // accountId
  webhookCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WebhooksApi#createAWebhook:");
  console.log(error.body);
});
