import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getContextInstanceSegmentsMembershipByEnv(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  {
    "address": {
      "city": "Springfield",
      "street": "123 Main Street"
    },
    "jobFunction": "doctor",
    "key": "context-key-123abc",
    "kind": "user",
    "name": "Sandy"
  }, // requestBody
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#getContextInstanceSegmentsMembershipByEnv:");
  console.log(error.body);
});
