import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const flagImportConfigurationPost: api.FlagImportConfigurationPost = {
  config: {
    "environmentId": "The ID of the environment in the external system",
    "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
    "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
    "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
    "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
    "workspaceApiKey": "An API key with read permissions in the external feature management system",
    "workspaceId": "The ID of the workspace in the external system"
  },
  name: "Sample configuration",
  tags: [
    "example-tag",
  ],
};

new api.FlagImportConfigurationsBetaApi(configuration).createFlagImportConfiguration(
  "projectKey_string", // projectKey
  "integrationKey_string", // integrationKey
  flagImportConfigurationPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
