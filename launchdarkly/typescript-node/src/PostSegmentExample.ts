import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const segmentBody = new models.SegmentBody();
segmentBody.name = "Example segment";
segmentBody.key = "segment-key-123abc";
segmentBody.description = "Bundle our sample customers together";
segmentBody.unbounded = false;
segmentBody.unboundedContextKind = "device";
segmentBody.tags = [
  "testing",
];

apiCaller.postSegment(
  undefined, // projectKey
  undefined, // environmentKey
  segmentBody,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#postSegment:");
  console.log(error.body);
});
