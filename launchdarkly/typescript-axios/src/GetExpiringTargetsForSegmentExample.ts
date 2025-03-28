import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.SegmentsApi(configuration).getExpiringTargetsForSegment(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "segmentKey_string", // segmentKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#getExpiringTargetsForSegment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
