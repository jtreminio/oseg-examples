import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ContextsApi(configuration).deleteContextInstances(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "id_string", // id
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#deleteContextInstances:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
