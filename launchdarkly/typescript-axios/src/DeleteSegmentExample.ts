import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.SegmentsApi(configuration).deleteSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#deleteSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
