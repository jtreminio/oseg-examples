import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getHoldout(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutKey_string", // holdoutKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBetaApi#getHoldout:");
  console.log(error.body);
});
