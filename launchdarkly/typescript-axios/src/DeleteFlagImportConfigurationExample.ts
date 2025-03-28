import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FlagImportConfigurationsBetaApi(configuration).deleteFlagImportConfiguration(
  "projectKey_string", // projectKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagImportConfigurationsBetaApi#deleteFlagImportConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
