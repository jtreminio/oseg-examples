import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getReleaseByFlagKey(
  undefined, // projectKey
  undefined, // flagKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBeta#getReleaseByFlagKey:");
  console.log(error.body);
});
