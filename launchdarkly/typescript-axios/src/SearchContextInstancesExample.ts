import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const contextInstanceSearch: api.ContextInstanceSearch = {
  filter: "{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}",
  sort: "-ts",
  limit: 10,
  continuationToken: "QAGFKH1313KUGI2351",
};

new api.ContextsApi(configuration).searchContextInstances(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  contextInstanceSearch,
  undefined, // limit
  undefined, // continuationToken
  undefined, // sort
  undefined, // filter
  undefined, // includeTotalCount
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ContextsApi#searchContextInstances:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
