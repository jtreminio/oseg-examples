import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const segmentBody: models.SegmentBody = {
  name: "Example segment",
  key: "segment-key-123abc",
  description: "Bundle our sample customers together",
  unbounded: false,
  unboundedContextKind: "device",
  tags: [
    "testing",
  ],
};

apiCaller.postSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  segmentBody,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#postSegment:");
  console.log(error.body);
});
