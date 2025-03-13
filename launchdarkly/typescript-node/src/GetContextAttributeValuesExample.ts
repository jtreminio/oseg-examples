import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getContextAttributeValues(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "attributeName_string", // attributeName
  undefined, // filter
  undefined, // limit
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#getContextAttributeValues:");
  console.log(error.body);
});
