import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const upsertContextKindPayload: api.UpsertContextKindPayload = {
  name: "organization",
  description: "An example context kind for organizations",
  hideInTargeting: false,
  archived: false,
  version: 1,
};

new api.ContextsApi(configuration).putContextKind(
  "projectKey_string", // projectKey
  "key_string", // key
  upsertContextKindPayload,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#putContextKind:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
