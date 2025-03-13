import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getContextKindsByProjectKey(
  "projectKey_string", // projectKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#getContextKindsByProjectKey:");
  console.log(error.body);
});
