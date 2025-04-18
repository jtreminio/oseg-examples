import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountUsageBetaApi();
apiCaller.setApiKey(api.AccountUsageBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getStreamUsageBySdkVersion(
  "source_string", // source
  undefined, // from
  undefined, // to
  undefined, // tz
  undefined, // sdk
  undefined, // version
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountUsageBetaApi#getStreamUsageBySdkVersion:");
  console.log(error.body);
});
