import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAllWebhooks().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WebhooksApi#getAllWebhooks:");
  console.log(error.body);
});
