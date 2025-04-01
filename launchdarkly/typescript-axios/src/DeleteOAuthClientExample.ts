import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.OAuth2ClientsApi(configuration).deleteOAuthClient(
  "clientId_string", // clientId
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling OAuth2ClientsApi#deleteOAuthClient:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
