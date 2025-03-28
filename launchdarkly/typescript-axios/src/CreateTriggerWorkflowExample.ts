import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const triggerPost: api.TriggerPost = {
  integrationKey: "generic-trigger",
  comment: "example comment",
  instructions: [
    {
      "kind": "turnFlagOn"
    }
  ],
};

new api.FlagTriggersApi(configuration).createTriggerWorkflow(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "featureFlagKey_string", // featureFlagKey
  triggerPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagTriggersApi#createTriggerWorkflow:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
