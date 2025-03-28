import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsPullRequestsBetaApi(configuration).getPullRequests(
  "projectKey_string", // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // status
  undefined, // query
  undefined, // limit
  undefined, // expand
  undefined, // sort
  undefined, // from
  undefined, // to
  undefined, // after
  undefined, // before
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsPullRequestsBetaApi#getPullRequests:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
