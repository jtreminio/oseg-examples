import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationAuditLogSubscriptionsApi();
apiCaller.setApiKey(api.IntegrationAuditLogSubscriptionsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patchOperation1: models.PatchOperation = {
  op: "replace",
  path: "/on",
};

const patchOperation = [
  patchOperation1,
];

apiCaller.updateSubscription(
  "integrationKey_string", // integrationKey
  "id_string", // id
  patchOperation,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationAuditLogSubscriptionsApi#updateSubscription:");
  console.log(error.body);
});
