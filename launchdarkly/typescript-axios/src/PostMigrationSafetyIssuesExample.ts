import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const flagSempatch: api.FlagSempatch = {
  instructions: [],
};

new api.FeatureFlagsApi(configuration).postMigrationSafetyIssues(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  "environmentKey_string", // environmentKey
  flagSempatch,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#postMigrationSafetyIssues:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
