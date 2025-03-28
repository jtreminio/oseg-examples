import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.PersistentStoreIntegrationsBetaApi(configuration).getBigSegmentStoreIntegration(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "integrationKey_string", // integrationKey
  "integrationId_string", // integrationId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PersistentStoreIntegrationsBetaApi#getBigSegmentStoreIntegration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
