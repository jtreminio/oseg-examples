import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FollowFlagsApi();
apiCaller.setApiKey(api.FollowFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteFlagFollower(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
  undefined, // memberId
).catch(error => {
  console.log("Exception when calling FollowFlagsApi#deleteFlagFollower:");
  console.log(error.body);
});
