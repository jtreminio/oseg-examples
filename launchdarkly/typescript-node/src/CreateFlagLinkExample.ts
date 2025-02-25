import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FlagLinksBetaApi();
apiCaller.setApiKey(api.FlagLinksBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const flagLinkPost = new models.FlagLinkPost();
flagLinkPost.key = "flag-link-key-123abc";
flagLinkPost.deepLink = "https://example.com/archives/123123123";
flagLinkPost.title = "Example link title";
flagLinkPost.description = "Example link description";

apiCaller.createFlagLink(
  undefined, // projectKey
  undefined, // featureFlagKey
  flagLinkPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FlagLinksBeta#createFlagLink:");
  console.log(error.body);
});
