import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAllReleaseProgressionsForReleasePipeline(
  undefined, // projectKey
  undefined, // pipelineKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#getAllReleaseProgressionsForReleasePipeline:");
  console.log(error.body);
});
