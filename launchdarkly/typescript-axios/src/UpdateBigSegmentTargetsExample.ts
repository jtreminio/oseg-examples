import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const included: api.SegmentUserList = {
  add: [
  ],
  remove: [
  ],
};

const excluded: api.SegmentUserList = {
  add: [
  ],
  remove: [
  ],
};

const segmentUserState: api.SegmentUserState = {
  included: included,
  excluded: excluded,
};

new api.SegmentsApi(configuration).updateBigSegmentTargets(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  segmentUserState,
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#updateBigSegmentTargets:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
