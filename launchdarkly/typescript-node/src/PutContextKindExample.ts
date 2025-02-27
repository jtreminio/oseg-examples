import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

const upsertContextKindPayload = new models.UpsertContextKindPayload();
upsertContextKindPayload.name = "organization";
upsertContextKindPayload.description = "An example context kind for organizations";
upsertContextKindPayload.hideInTargeting = false;
upsertContextKindPayload.archived = false;
upsertContextKindPayload.version = 1;

apiCaller.putContextKind(
  undefined, // projectKey
  undefined, // key
  upsertContextKindPayload,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#putContextKind:");
  console.log(error.body);
});
