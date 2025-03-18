import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.OAuth2ClientsApi();
apiCaller.setApiKey(api.OAuth2ClientsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteOAuthClient(
  "clientId_string", // clientId
).catch(error => {
  console.log("Exception when calling OAuth2ClientsApi#deleteOAuthClient:");
  console.log(error.body);
});
