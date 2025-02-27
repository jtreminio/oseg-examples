import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1 = new models.PatchOperation();
patch1.op = "replace";
patch1.path = "/description";

const patch2 = new models.PatchOperation();
patch2.op = "add";
patch2.path = "/tags/0";

const patch = [
  patch1,
  patch2,
];

const patchWithComment = new models.PatchWithComment();
patchWithComment.patch = patch;

apiCaller.patchSegment(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
  patchWithComment,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling SegmentsApi#patchSegment:");
  console.log(error.body);
});
