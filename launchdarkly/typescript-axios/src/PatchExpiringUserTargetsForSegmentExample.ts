import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const instructions1: api.PatchSegmentInstruction = {
  kind: api.PatchSegmentInstructionKindEnum.AddExpireUserTargetDate,
  userKey: "sample-user-key",
  targetType: api.PatchSegmentInstructionTargetTypeEnum.Included,
  value: 16534692,
  version: 0,
};

const instructions = [
  instructions1,
];

const patchSegmentRequest: api.PatchSegmentRequest = {
  comment: "optional comment",
  instructions: instructions,
};

new api.SegmentsApi(configuration).patchExpiringUserTargetsForSegment(
  "the-project-key", // projectKey
  "the-environment-key", // environmentKey
  "the-segment-key", // segmentKey
  patchSegmentRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#patchExpiringUserTargetsForSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
