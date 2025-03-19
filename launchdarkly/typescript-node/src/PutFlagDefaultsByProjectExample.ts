import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ProjectsApi();
apiCaller.setApiKey(api.ProjectsApiApiKeys.ApiKey, "YOUR_API_KEY");

const booleanDefaults: models.BooleanFlagDefaults = {
  trueDisplayName: "True",
  falseDisplayName: "False",
  trueDescription: "serve true",
  falseDescription: "serve false",
  onVariation: 0,
  offVariation: 1,
};

const defaultClientSideAvailability: models.DefaultClientSideAvailability = {
  usingMobileKey: true,
  usingEnvironmentId: true,
};

const upsertFlagDefaultsPayload: models.UpsertFlagDefaultsPayload = {
  temporary: true,
  tags: [
    "tag-1",
    "tag-2",
  ],
  booleanDefaults: booleanDefaults,
  defaultClientSideAvailability: defaultClientSideAvailability,
};

apiCaller.putFlagDefaultsByProject(
  "projectKey_string", // projectKey
  upsertFlagDefaultsPayload,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ProjectsApi#putFlagDefaultsByProject:");
  console.log(error.body);
});
