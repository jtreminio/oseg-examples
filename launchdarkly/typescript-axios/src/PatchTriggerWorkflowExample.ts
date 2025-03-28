import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const flagTriggerInput: api.FlagTriggerInput = {
  comment: "optional comment",
  instructions: [
    {
      "kind": "disableTrigger"
    }
  ],
};

new api.FlagTriggersApi(configuration).patchTriggerWorkflow(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  "id_string", // id
  flagTriggerInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagTriggersApi#patchTriggerWorkflow:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
