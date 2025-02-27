import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const instructions1 = new models.PatchSegmentInstruction();
instructions1.kind = models.PatchSegmentInstruction.KindEnum.AddExpireUserTargetDate;
instructions1.userKey = "sample-user-key";
instructions1.targetType = models.PatchSegmentInstruction.TargetTypeEnum.Included;
instructions1.value = 16534692;
instructions1.version = 0;

const instructions = [
  instructions1,
];

const patchSegmentRequest = new models.PatchSegmentRequest();
patchSegmentRequest.comment = "optional comment";
patchSegmentRequest.instructions = instructions;

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
