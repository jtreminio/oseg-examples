import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FeatureFlagsApi(configuration).getFeatureFlags(
  "projectKey_string", // projectKey
  undefined, // env
  undefined, // tag
  undefined, // limit
  undefined, // offset
  undefined, // archived
  undefined, // summary
  undefined, // filter
  undefined, // sort
  undefined, // compare
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#getFeatureFlags:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
