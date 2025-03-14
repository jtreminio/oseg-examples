import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagImportConfigurationsBetaApi();
apiCaller.setApiKey(api.FlagImportConfigurationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagImportConfigurationPost = new models.FlagImportConfigurationPost();
flagImportConfigurationPost.config = {
  "environmentId": "The ID of the environment in the external system",
  "ldApiKey": "An API key with create flag permissions in your LaunchDarkly account",
  "ldMaintainer": "The ID of the member who will be the maintainer of the imported flags",
  "ldTag": "A tag to apply to all flags imported to LaunchDarkly",
  "splitTag": "If provided, imports only the flags from the external system with this tag. Leave blank to import all flags.",
  "workspaceApiKey": "An API key with read permissions in the external feature management system",
  "workspaceId": "The ID of the workspace in the external system"
};
flagImportConfigurationPost.name = "Sample configuration";
flagImportConfigurationPost.tags = [
  "example-tag",
];

apiCaller.createFlagImportConfiguration(
  undefined, // projectKey
  undefined, // integrationKey
  flagImportConfigurationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagImportConfigurationsBetaApi#createFlagImportConfiguration:");
  console.log(error.body);
});
