import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const segmentBody: api.SegmentBody = {
  name: "Example segment",
  key: "segment-key-123abc",
  description: "Bundle our sample customers together",
  unbounded: false,
  unboundedContextKind: "device",
  tags: [
    "testing",
  ],
};

new api.SegmentsApi(configuration).postSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  segmentBody,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#postSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
