import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.PersistentStoreIntegrationsBetaApi();
apiCaller.setApiKey(api.PersistentStoreIntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getBigSegmentStoreIntegrations().then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#getBigSegmentStoreIntegrations:");
  console.log(error.body);
});
