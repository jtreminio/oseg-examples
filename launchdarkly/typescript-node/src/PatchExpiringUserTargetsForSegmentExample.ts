import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const instructions1: models.PatchSegmentInstruction = {
  kind: models.PatchSegmentInstruction.KindEnum.AddExpireUserTargetDate,
  userKey: "sample-user-key",
  targetType: models.PatchSegmentInstruction.TargetTypeEnum.Included,
  value: 16534692,
  version: 0,
};

const instructions = [
  instructions1,
];

const patchSegmentRequest: models.PatchSegmentRequest = {
  comment: "optional comment",
  instructions: instructions,
};

apiCaller.patchExpiringUserTargetsForSegment(
  "the-project-key", // projectKey
  "the-environment-key", // environmentKey
  "the-segment-key", // segmentKey
  patchSegmentRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#patchExpiringUserTargetsForSegment:");
  console.log(error.body);
});
