import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsScoresBetaApi(configuration).deleteInsightGroup(
  "insightGroupKey_string", // insightGroupKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsScoresBetaApi#deleteInsightGroup:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
