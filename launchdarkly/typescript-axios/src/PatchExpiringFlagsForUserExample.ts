import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const instructions1: api.InstructionUserRequest = {
  kind: api.InstructionUserRequestKindEnum.AddExpireUserTargetDate,
  flagKey: "sample-flag-key",
  variationId: "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d",
  value: 16534692,
  version: 1,
};

const instructions = [
  instructions1,
];

const patchUsersRequest: api.PatchUsersRequest = {
  comment: "optional comment",
  instructions: instructions,
};

new api.UserSettingsApi(configuration).patchExpiringFlagsForUser(
  "the-project-key", // projectKey
  "the-user-key", // userKey
  "the-environment-key", // environmentKey
  patchUsersRequest,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UserSettingsApi#patchExpiringFlagsForUser:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
