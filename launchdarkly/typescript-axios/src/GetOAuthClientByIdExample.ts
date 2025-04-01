import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.OAuth2ClientsApi(configuration).getOAuthClientById(
  "clientId_string", // clientId
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling OAuth2ClientsApi#getOAuthClientById:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
