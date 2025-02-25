import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationAuditLogSubscriptionsApi();
apiCaller.setApiKey(api.IntegrationAuditLogSubscriptionsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getSubscriptionByID(
  undefined, // integrationKey
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationAuditLogSubscriptions#getSubscriptionByID:");
  console.log(error.body);
});
