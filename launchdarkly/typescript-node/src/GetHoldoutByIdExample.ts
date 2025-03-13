import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.HoldoutsBetaApi();
apiCaller.setApiKey(api.HoldoutsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getHoldoutById(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "holdoutId_string", // holdoutId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HoldoutsBetaApi#getHoldoutById:");
  console.log(error.body);
});
