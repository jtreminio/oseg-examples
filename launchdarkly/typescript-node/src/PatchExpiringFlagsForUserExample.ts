import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UserSettingsApi();
apiCaller.setApiKey(api.UserSettingsApiApiKeys.ApiKey, "YOUR_API_KEY");

const instructions1: models.InstructionUserRequest = {
  kind: models.InstructionUserRequest.KindEnum.AddExpireUserTargetDate,
  flagKey: "sample-flag-key",
  variationId: "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d",
  value: 16534692,
  version: 1,
};

const instructions = [
  instructions1,
];

const patchUsersRequest: models.PatchUsersRequest = {
  comment: "optional comment",
  instructions: instructions,
};

apiCaller.patchExpiringFlagsForUser(
  "the-project-key", // projectKey
  "the-user-key", // userKey
  "the-environment-key", // environmentKey
  patchUsersRequest,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UserSettingsApi#patchExpiringFlagsForUser:");
  console.log(error.body);
});
