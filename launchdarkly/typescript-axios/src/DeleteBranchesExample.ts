import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.CodeReferencesApi(configuration).deleteBranches(
  "repo_string", // repo
  [
    "branch-to-be-deleted",
    "another-branch-to-be-deleted",
  ], // requestBody
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CodeReferencesApi#deleteBranches:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
