import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ApprovalsApi(configuration).deleteApprovalRequestForFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ApprovalsApi#deleteApprovalRequestForFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
