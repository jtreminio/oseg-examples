import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.createBigSegmentExport(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
).catch(error => {
  console.log("Exception when calling SegmentsApi#createBigSegmentExport:");
  console.log(error.body);
});
