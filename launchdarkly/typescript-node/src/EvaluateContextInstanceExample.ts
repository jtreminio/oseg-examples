import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.evaluateContextInstance(
  undefined, // projectKey
  undefined, // environmentKey
    {
    "key": "user-key-123abc",
    "kind": "user",
    "otherAttribute": "other attribute value"
  }, // requestBody
  undefined, // limit
  undefined, // offset
  undefined, // sort
  undefined, // filter
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#evaluateContextInstance:");
  console.log(error.body);
});
