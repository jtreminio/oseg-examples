import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OAuth2ClientsApi();
apiCaller.setApiKey(api.OAuth2ClientsApiApiKeys.ApiKey, "YOUR_API_KEY");

const oauthClientPost = new models.OauthClientPost();

apiCaller.createOAuth2Client(
  oauthClientPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling OAuth2ClientsApi#createOAuth2Client:");
  console.log(error.body);
});
