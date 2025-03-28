import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsChartsBetaApi(configuration).getLeadTimeChart(
  "projectKey_string", // projectKey
  undefined, // environmentKey
  undefined, // applicationKey
  undefined, // from
  undefined, // to
  undefined, // bucketType
  undefined, // bucketMs
  undefined, // groupBy
  undefined, // expand
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsChartsBetaApi#getLeadTimeChart:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
