import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsChartsBetaApi(configuration).getStaleFlagsChart(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // applicationKey
  undefined, // groupBy
  undefined, // maintainerId
  undefined, // maintainerTeamKey
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsChartsBetaApi#getStaleFlagsChart:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
