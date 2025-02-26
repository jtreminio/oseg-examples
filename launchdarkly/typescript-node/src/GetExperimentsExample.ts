import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getExperiments(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // limit
  undefined, // offset
  undefined, // filter
  undefined, // expand
  undefined, // lifecycleState
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#getExperiments:");
  console.log(error.body);
});
