import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const patch1: api.PatchOperation = {
  op: "replace",
  path: "/policy/0",
};

const patch = [
  patch1,
];

const patchWithComment: api.PatchWithComment = {
  patch: patch,
};

new api.RelayProxyConfigurationsApi(configuration).patchRelayAutoConfig(
  "id_string", // id
  patchWithComment,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling RelayProxyConfigurationsApi#patchRelayAutoConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
