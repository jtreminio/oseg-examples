import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ApplicationsBetaApi();
apiCaller.setApiKey(api.ApplicationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getApplication(
  "applicationKey_string", // applicationKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ApplicationsBetaApi#getApplication:");
  console.log(error.body);
});
