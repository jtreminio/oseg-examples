import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const instructions1 = new models.PatchSegmentExpiringTargetInstruction();
instructions1.kind = models.PatchSegmentExpiringTargetInstruction.KindEnum.UpdateExpiringTarget;
instructions1.contextKey = "user@email.com";
instructions1.contextKind = "user";
instructions1.targetType = models.PatchSegmentExpiringTargetInstruction.TargetTypeEnum.Included;
instructions1.value = 1587582000000;
instructions1.version = 0;

const instructions = [
  instructions1,
];

const patchSegmentExpiringTargetInputRep = new models.PatchSegmentExpiringTargetInputRep();
patchSegmentExpiringTargetInputRep.comment = "optional comment";
patchSegmentExpiringTargetInputRep.instructions = instructions;

apiCaller.patchExpiringTargetsForSegment(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
  patchSegmentExpiringTargetInputRep,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Segments#patchExpiringTargetsForSegment:");
  console.log(error.body);
});
