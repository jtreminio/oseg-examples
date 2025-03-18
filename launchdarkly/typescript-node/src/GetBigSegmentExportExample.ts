import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getBigSegmentExport(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  "exportID_string", // exportID
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#getBigSegmentExport:");
  console.log(error.body);
});
