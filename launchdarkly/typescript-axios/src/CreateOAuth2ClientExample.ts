import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const oauthClientPost: api.OauthClientPost = {
};

new api.OAuth2ClientsApi(configuration).createOAuth2Client(
  oauthClientPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling OAuth2ClientsApi#createOAuth2Client:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
