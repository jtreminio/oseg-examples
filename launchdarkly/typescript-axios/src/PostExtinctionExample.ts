import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const extinction1: api.Extinction = {
  revision: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
  message: "Remove flag for launched feature",
  time: 1706701522000,
  flagKey: "enable-feature",
  projKey: "default",
};

const extinction = [
  extinction1,
];

new api.CodeReferencesApi(configuration).postExtinction(
  "repo_string", // repo
  "branch_string", // branch
  extinction,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CodeReferencesApi#postExtinction:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
