import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const clientSideAvailability: models.ClientSideAvailabilityPost = {
  usingEnvironmentId: true,
  usingMobileKey: true,
};

const featureFlagBody: models.FeatureFlagBody = {
  name: "My Flag",
  key: "flag-key-123abc",
  clientSideAvailability: clientSideAvailability,
};

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
