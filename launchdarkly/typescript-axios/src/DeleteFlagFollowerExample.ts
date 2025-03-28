import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FollowFlagsApi(configuration).deleteFlagFollower(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "memberId_string", // memberId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FollowFlagsApi#deleteFlagFollower:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
