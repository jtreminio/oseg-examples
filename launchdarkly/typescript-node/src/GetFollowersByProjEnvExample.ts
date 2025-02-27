import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FollowFlagsApi();
apiCaller.setApiKey(api.FollowFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFollowersByProjEnv(
  undefined, // projectKey
  undefined, // environmentKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FollowFlagsApi#getFollowersByProjEnv:");
  console.log(error.body);
});
