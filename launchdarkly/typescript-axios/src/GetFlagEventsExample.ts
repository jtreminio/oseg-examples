import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsFlagEventsBetaApi(configuration).getFlagEvents(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
  undefined, // query
  undefined, // impactSize
  undefined, // hasExperiments
  undefined, // global
  undefined, // expand
  undefined, // limit
  undefined, // from
  undefined, // to
  undefined, // after
  undefined, // before
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsFlagEventsBetaApi#getFlagEvents:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
