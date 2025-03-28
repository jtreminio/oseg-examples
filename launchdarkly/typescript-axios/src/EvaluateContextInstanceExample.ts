import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ContextsApi(configuration).evaluateContextInstance(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  {
    "key": "user-key-123abc",
    "kind": "user",
    "otherAttribute": "other attribute value"
  }, // requestBody
  undefined, // limit
  undefined, // offset
  undefined, // sort
  undefined, // filter
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#evaluateContextInstance:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
