import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const flagLinkPost: api.FlagLinkPost = {
  key: "flag-link-key-123abc",
  deepLink: "https://example.com/archives/123123123",
  title: "Example link title",
  description: "Example link description",
};

new api.FlagLinksBetaApi(configuration).createFlagLink(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  flagLinkPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FlagLinksBetaApi#createFlagLink:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
