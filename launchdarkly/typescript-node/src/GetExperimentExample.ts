import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExperiment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#getExperiment:");
  console.log(error.body);
});
