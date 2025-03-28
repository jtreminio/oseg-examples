import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const booleanDefaults: api.BooleanFlagDefaults = {
  trueDisplayName: "True",
  falseDisplayName: "False",
  trueDescription: "serve true",
  falseDescription: "serve false",
  onVariation: 0,
  offVariation: 1,
};

const defaultClientSideAvailability: api.DefaultClientSideAvailability = {
  usingMobileKey: true,
  usingEnvironmentId: true,
};

const upsertFlagDefaultsPayload: api.UpsertFlagDefaultsPayload = {
  temporary: true,
  tags: [
    "tag-1",
    "tag-2",
  ],
  booleanDefaults: booleanDefaults,
  defaultClientSideAvailability: defaultClientSideAvailability,
};

new api.ProjectsApi(configuration).putFlagDefaultsByProject(
  "projectKey_string", // projectKey
  upsertFlagDefaultsPayload,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#putFlagDefaultsByProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
