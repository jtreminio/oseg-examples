import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ContextsApi(configuration).getContextInstances(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
  undefined, // limit
  undefined, // continuationToken
  undefined, // sort
  undefined, // filter
  undefined, // includeTotalCount
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#getContextInstances:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
