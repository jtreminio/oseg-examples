import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.WebhooksApi();
apiCaller.setApiKey(api.WebhooksApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1 = new models.PatchOperation();
patchOperation1.op = "replace";
patchOperation1.path = "/on";

const patchOperation = [
  patchOperation1,
];

apiCaller.patchWebhook(
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling WebhooksApi#patchWebhook:");
  console.log(error.body);
});
