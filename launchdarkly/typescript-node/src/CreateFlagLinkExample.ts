import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagLinksBetaApi();
apiCaller.setApiKey(api.FlagLinksBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagLinkPost: models.FlagLinkPost = {
  key: "flag-link-key-123abc",
  deepLink: "https://example.com/archives/123123123",
  title: "Example link title",
  description: "Example link description",
};

apiCaller.createFlagLink(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  flagLinkPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagLinksBetaApi#createFlagLink:");
  console.log(error.body);
});
