import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const instructions1: models.PatchSegmentExpiringTargetInstruction = {
  kind: models.PatchSegmentExpiringTargetInstruction.KindEnum.UpdateExpiringTarget,
  contextKey: "user@email.com",
  contextKind: "user",
  targetType: models.PatchSegmentExpiringTargetInstruction.TargetTypeEnum.Included,
  value: 1587582000000,
  version: 0,
};

const instructions = [
  instructions1,
];

const patchSegmentExpiringTargetInputRep: models.PatchSegmentExpiringTargetInputRep = {
  comment: "optional comment",
  instructions: instructions,
};

apiCaller.patchExpiringTargetsForSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  patchSegmentExpiringTargetInputRep,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#patchExpiringTargetsForSegment:");
  console.log(error.body);
});
