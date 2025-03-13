import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getFeatureFlags(
  "projectKey_string", // projectKey
  undefined, // env
  undefined, // tag
  undefined, // limit
  undefined, // offset
  undefined, // archived
  undefined, // summary
  undefined, // filter
  undefined, // sort
  undefined, // compare
  undefined, // expand
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#getFeatureFlags:");
  console.log(error.body);
});
