import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const flagScheduledChangesInput: api.FlagScheduledChangesInput = {
  instructions: [
    {
      "kind": "replaceScheduledChangesInstructions",
      "value": [
        {
          "kind": "turnFlagOff"
        }
      ]
    }
  ],
  comment: "Optional comment describing the update to the scheduled changes",
};

new api.ScheduledChangesApi(configuration).patchFlagConfigScheduledChange(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  flagScheduledChangesInput,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ScheduledChangesApi#patchFlagConfigScheduledChange:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
