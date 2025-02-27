import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getReleasePipelineByKey(
  undefined, // projectKey
  undefined, // pipelineKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#getReleasePipelineByKey:");
  console.log(error.body);
});
