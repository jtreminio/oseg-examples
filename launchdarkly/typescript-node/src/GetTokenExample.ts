import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AccessTokensApi();
apiCaller.setApiKey(api.AccessTokensApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getToken(
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AccessTokensApi#getToken:");
  console.log(error.body);
});
