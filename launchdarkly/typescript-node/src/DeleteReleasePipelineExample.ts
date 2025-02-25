import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteReleasePipeline(
  undefined, // projectKey
  undefined, // pipelineKey
).catch(error => {
  console.log("Exception when calling ReleasePipelinesBeta#deleteReleasePipeline:");
  console.log(error.body);
});
