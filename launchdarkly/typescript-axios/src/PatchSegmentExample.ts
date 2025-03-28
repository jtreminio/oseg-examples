import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patch1: api.PatchOperation = {
  op: "replace",
  path: "/description",
};

const patch2: api.PatchOperation = {
  op: "add",
  path: "/tags/0",
};

const patch = [
  patch1,
  patch2,
];

const patchWithComment: api.PatchWithComment = {
  patch: patch,
};

new api.SegmentsApi(configuration).patchSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
  patchWithComment,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#patchSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
