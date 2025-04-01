import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ContextsApi(configuration).getContextAttributeValues(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "attributeName_string", // attributeName
  undefined, // filter
  undefined, // limit
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#getContextAttributeValues:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
