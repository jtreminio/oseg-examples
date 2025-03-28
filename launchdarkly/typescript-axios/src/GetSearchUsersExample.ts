import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.UsersApi(configuration).getSearchUsers(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // q
  undefined, // limit
  undefined, // offset
  undefined, // after
  undefined, // sort
  undefined, // searchAfter
  undefined, // filter
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling UsersApi#getSearchUsers:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
