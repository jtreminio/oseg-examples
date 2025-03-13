import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FollowFlagsApi();
apiCaller.setApiKey(api.FollowFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFlagFollower(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "memberId_string", // memberId
).catch(error => {
  console.log("Exception when calling FollowFlagsApi#deleteFlagFollower:");
  console.log(error.body);
});
