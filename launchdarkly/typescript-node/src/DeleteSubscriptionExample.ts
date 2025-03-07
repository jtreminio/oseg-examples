import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationAuditLogSubscriptionsApi();
apiCaller.setApiKey(api.IntegrationAuditLogSubscriptionsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteSubscription(
  undefined, // integrationKey
  undefined, // id
).catch(error => {
  console.log("Exception when calling IntegrationAuditLogSubscriptionsApi#deleteSubscription:");
  console.log(error.body);
});
