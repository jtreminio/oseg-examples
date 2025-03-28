import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.SegmentsApi(configuration).getContextInstanceSegmentsMembershipByEnv(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  {
    "address": {
      "city": "Springfield",
      "street": "123 Main Street"
    },
    "jobFunction": "doctor",
    "key": "context-key-123abc",
    "kind": "user",
    "name": "Sandy"
  }, // requestBody
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling SegmentsApi#getContextInstanceSegmentsMembershipByEnv:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
