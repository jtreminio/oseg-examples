import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteContextInstances(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).catch(error => {
  console.log("Exception when calling ContextsApi#deleteContextInstances:");
  console.log(error.body);
});
