import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const experimentPatchInput: api.ExperimentPatchInput = {
  instructions: [
    {
      "kind": "updateName",
      "value": "Updated experiment name"
    }
  ],
  comment: "Example comment describing the update",
};

new api.ExperimentsApi(configuration).patchExperiment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "experimentKey_string", // experimentKey
  experimentPatchInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#patchExperiment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
