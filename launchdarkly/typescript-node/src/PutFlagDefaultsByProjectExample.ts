import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

const booleanDefaults = new models.BooleanFlagDefaults();
booleanDefaults.trueDisplayName = "True";
booleanDefaults.falseDisplayName = "False";
booleanDefaults.trueDescription = "serve true";
booleanDefaults.falseDescription = "serve false";
booleanDefaults.onVariation = 0;
booleanDefaults.offVariation = 1;

const defaultClientSideAvailability = new models.DefaultClientSideAvailability();
defaultClientSideAvailability.usingMobileKey = true;
defaultClientSideAvailability.usingEnvironmentId = true;

const upsertFlagDefaultsPayload = new models.UpsertFlagDefaultsPayload();
upsertFlagDefaultsPayload.temporary = true;
upsertFlagDefaultsPayload.tags = [
  "tag-1",
  "tag-2",
];
upsertFlagDefaultsPayload.booleanDefaults = booleanDefaults;
upsertFlagDefaultsPayload.defaultClientSideAvailability = defaultClientSideAvailability;

apiCaller.putFlagDefaultsByProject(
  "projectKey_string", // projectKey
  upsertFlagDefaultsPayload,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ProjectsApi#putFlagDefaultsByProject:");
  console.log(error.body);
});
