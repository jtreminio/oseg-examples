import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.CodeReferencesApi(configuration).getRepository(
  "repo_string", // repo
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CodeReferencesApi#getRepository:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
