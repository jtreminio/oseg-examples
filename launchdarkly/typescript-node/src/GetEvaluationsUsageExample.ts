import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccountUsageBetaApi();
apiCaller.setApiKey(api.AccountUsageBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getEvaluationsUsage(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  undefined, // from
  undefined, // to
  undefined, // tz
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccountUsageBetaApi#getEvaluationsUsage:");
  console.log(error.body);
});
