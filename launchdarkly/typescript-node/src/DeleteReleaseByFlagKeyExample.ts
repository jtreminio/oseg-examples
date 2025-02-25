import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteReleaseByFlagKey(
  undefined, // projectKey
  undefined, // flagKey
).catch(error => {
  console.log("Exception when calling ReleasesBeta#deleteReleaseByFlagKey:");
  console.log(error.body);
});
