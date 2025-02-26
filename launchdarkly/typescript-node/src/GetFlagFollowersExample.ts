import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FollowFlagsApi();
apiCaller.setApiKey(api.FollowFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFlagFollowers(
  undefined, // projectKey
  undefined, // featureFlagKey
  undefined, // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FollowFlagsApi#getFlagFollowers:");
  console.log(error.body);
});
