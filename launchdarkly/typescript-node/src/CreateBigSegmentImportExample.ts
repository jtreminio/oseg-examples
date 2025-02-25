import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.createBigSegmentImport(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
  undefined, // file
  undefined, // mode
  undefined, // waitOnApprovals
).catch(error => {
  console.log("Exception when calling Segments#createBigSegmentImport:");
  console.log(error.body);
});
