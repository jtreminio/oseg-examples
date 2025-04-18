import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsScoresBetaApi(configuration).getInsightsScores(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsScoresBetaApi#getInsightsScores:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
