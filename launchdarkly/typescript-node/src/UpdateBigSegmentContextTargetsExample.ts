import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const included: models.SegmentUserList = {
  add: [
  ],
  remove: [
  ],
};

const excluded: models.SegmentUserList = {
  add: [
  ],
  remove: [
  ],
};

const segmentUserState: models.SegmentUserState = {
  included: included,
  excluded: excluded,
};

apiCaller.updateBigSegmentContextTargets(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  segmentUserState,
).catch(error => {
  console.log("Exception when calling SegmentsApi#updateBigSegmentContextTargets:");
  console.log(error.body);
});
