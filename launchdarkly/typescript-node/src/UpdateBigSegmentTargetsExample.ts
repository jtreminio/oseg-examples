import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const included = new models.SegmentUserList();
included.add = [
];
included.remove = [
];

const excluded = new models.SegmentUserList();
excluded.add = [
];
excluded.remove = [
];

const segmentUserState = new models.SegmentUserState();
segmentUserState.included = included;
segmentUserState.excluded = excluded;

apiCaller.updateBigSegmentTargets(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
  segmentUserState,
).catch(error => {
  console.log("Exception when calling SegmentsApi#updateBigSegmentTargets:");
  console.log(error.body);
});
