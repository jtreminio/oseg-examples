import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.EnvironmentsApi();
apiCaller.setApiKey(api.EnvironmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.resetEnvironmentSDKKey(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // expiry
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling EnvironmentsApi#resetEnvironmentSDKKey:");
  console.log(error.body);
});
