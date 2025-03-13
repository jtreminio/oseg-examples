import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.PersistentStoreIntegrationsBetaApi();
apiCaller.setApiKey(api.PersistentStoreIntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteBigSegmentStoreIntegration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
).catch(error => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#deleteBigSegmentStoreIntegration:");
  console.log(error.body);
});
