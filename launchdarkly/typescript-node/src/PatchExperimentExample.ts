import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const experimentPatchInput: models.ExperimentPatchInput = {
  instructions: [
    {
      "kind": "updateName",
      "value": "Updated experiment name"
    }
  ],
  comment: "Example comment describing the update",
};

apiCaller.patchExperiment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  experimentPatchInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#patchExperiment:");
  console.log(error.body);
});
