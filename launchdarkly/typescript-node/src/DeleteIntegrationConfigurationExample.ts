import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationsBetaApi();
apiCaller.setApiKey(api.IntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteIntegrationConfiguration(
  "integrationConfigurationId_string", // integrationConfigurationId
).catch(error => {
  console.log("Exception when calling IntegrationsBetaApi#deleteIntegrationConfiguration:");
  console.log(error.body);
});
