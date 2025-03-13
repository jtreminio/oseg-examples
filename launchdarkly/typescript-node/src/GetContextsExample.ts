import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getContexts(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "kind_string", // kind
  "key_string", // key
  undefined, // limit
  undefined, // continuationToken
  undefined, // sort
  undefined, // filter
  undefined, // includeTotalCount
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#getContexts:");
  console.log(error.body);
});
