import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagImportConfigurationsBetaApi();
apiCaller.setApiKey(api.FlagImportConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFlagImportConfiguration(
  "projectKey_string", // projectKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
).catch(error => {
  console.log("Exception when calling FlagImportConfigurationsBetaApi#deleteFlagImportConfiguration:");
  console.log(error.body);
});
