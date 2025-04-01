import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const postFlagScheduledChangesInput: api.PostFlagScheduledChangesInput = {
  executionDate: 1718467200000,
  instructions: [
    {
      "kind": "turnFlagOn"
    }
  ],
  comment: "Optional comment describing the scheduled changes",
};

new api.ScheduledChangesApi(configuration).postFlagConfigScheduledChanges(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  postFlagScheduledChangesInput,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ScheduledChangesApi#postFlagConfigScheduledChanges:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
