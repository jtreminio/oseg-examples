import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAllReleasePipelines(
  undefined, // projectKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#getAllReleasePipelines:");
  console.log(error.body);
});
