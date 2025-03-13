import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const clientSideAvailability = new models.ClientSideAvailabilityPost();
clientSideAvailability.usingEnvironmentId = true;
clientSideAvailability.usingMobileKey = true;

const featureFlagBody = new models.FeatureFlagBody();
featureFlagBody.name = "My Flag";
featureFlagBody.key = "flag-key-123abc";
featureFlagBody.clientSideAvailability = clientSideAvailability;

apiCaller.postFeatureFlag(
  "projectKey_string", // projectKey
  featureFlagBody,
  undefined, // clone
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#postFeatureFlag:");
  console.log(error.body);
});
