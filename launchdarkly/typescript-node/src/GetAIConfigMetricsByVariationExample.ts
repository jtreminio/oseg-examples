import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AIConfigsBetaApi();
apiCaller.setApiKey(api.AIConfigsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAIConfigMetricsByVariation(
  undefined, // lDAPIVersion
  undefined, // projectKey
  undefined, // configKey
  123, // from
  456, // to
  undefined, // env
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AIConfigsBetaApi#getAIConfigMetricsByVariation:");
  console.log(error.body);
});
