import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const createReleaseInput = new models.CreateReleaseInput();
createReleaseInput.releasePipelineKey = undefined;
createReleaseInput.releaseVariationId = undefined;

apiCaller.createReleaseForFlag(
  undefined, // projectKey
  undefined, // flagKey
  createReleaseInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBetaApi#createReleaseForFlag:");
  console.log(error.body);
});
