import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getUser(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersApi#getUser:");
  console.log(error.body);
});
