import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationsBetaApi();
apiCaller.setApiKey(api.IntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAllIntegrationConfigurations(
  "integrationKey_string", // integrationKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationsBetaApi#getAllIntegrationConfigurations:");
  console.log(error.body);
});
