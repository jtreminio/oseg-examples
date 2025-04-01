import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const environmentPost: api.EnvironmentPost = {
  name: "My Environment",
  key: "environment-key-123abc",
  color: "DADBEE",
};

new api.EnvironmentsApi(configuration).postEnvironment(
  "projectKey_string", // projectKey
  environmentPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling EnvironmentsApi#postEnvironment:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
