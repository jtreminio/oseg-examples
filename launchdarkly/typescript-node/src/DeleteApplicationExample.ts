import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApplicationsBetaApi();
apiCaller.setApiKey(api.ApplicationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteApplication(
  undefined, // applicationKey
).catch(error => {
  console.log("Exception when calling ApplicationsBetaApi#deleteApplication:");
  console.log(error.body);
});
