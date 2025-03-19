import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

const upsertContextKindPayload: models.UpsertContextKindPayload = {
  name: "organization",
  description: "An example context kind for organizations",
  hideInTargeting: false,
  archived: false,
  version: 1,
};

apiCaller.putContextKind(
  "projectKey_string", // projectKey
  "key_string", // key
  upsertContextKindPayload,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#putContextKind:");
  console.log(error.body);
});
