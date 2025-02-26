import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.PersistentStoreIntegrationsBetaApi();
apiCaller.setApiKey(api.PersistentStoreIntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteBigSegmentStoreIntegration(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // integrationKey
  undefined, // integrationId
).catch(error => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#deleteBigSegmentStoreIntegration:");
  console.log(error.body);
});
