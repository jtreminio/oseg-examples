import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccessTokensApi();
apiCaller.setApiKey(api.AccessTokensApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteToken(
  "id_string", // id
).catch(error => {
  console.log("Exception when calling AccessTokensApi#deleteToken:");
  console.log(error.body);
});
