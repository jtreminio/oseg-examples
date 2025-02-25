import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagImportConfigurationsBetaApi();
apiCaller.setApiKey(api.FlagImportConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.triggerFlagImportJob(
  undefined, // projectKey
  undefined, // integrationKey
  undefined, // integrationId
).catch(error => {
  console.log("Exception when calling FlagImportConfigurationsBeta#triggerFlagImportJob:");
  console.log(error.body);
});
