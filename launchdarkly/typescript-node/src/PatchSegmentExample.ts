import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1: models.PatchOperation = {
  op: "replace",
  path: "/description",
};

const patch2: models.PatchOperation = {
  op: "add",
  path: "/tags/0",
};

const patch = [
  patch1,
  patch2,
];

const patchWithComment: models.PatchWithComment = {
  patch: patch,
};

apiCaller.patchSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#patchSegment:");
  console.log(error.body);
});
