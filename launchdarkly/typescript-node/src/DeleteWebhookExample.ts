import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteWebhook(
  undefined, // id
).catch(error => {
  console.log("Exception when calling Webhooks#deleteWebhook:");
  console.log(error.body);
});
