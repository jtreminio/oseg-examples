import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagSempatch = new models.FlagSempatch();
flagSempatch.instructions = [];
flagSempatch.comment = undefined;

apiCaller.postMigrationSafetyIssues(
  undefined, // projectKey
  undefined, // flagKey
  undefined, // environmentKey
  flagSempatch,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#postMigrationSafetyIssues:");
  console.log(error.body);
});
