import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const instructions1: api.PatchSegmentExpiringTargetInstruction = {
  kind: api.PatchSegmentExpiringTargetInstructionKindEnum.UpdateExpiringTarget,
  contextKey: "user@email.com",
  contextKind: "user",
  targetType: api.PatchSegmentExpiringTargetInstructionTargetTypeEnum.Included,
  value: 1587582000000,
  version: 0,
};

const instructions = [
  instructions1,
];

const patchSegmentExpiringTargetInputRep: api.PatchSegmentExpiringTargetInputRep = {
  comment: "optional comment",
  instructions: instructions,
};

new api.SegmentsApi(configuration).patchExpiringTargetsForSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  patchSegmentExpiringTargetInputRep,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#patchExpiringTargetsForSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
