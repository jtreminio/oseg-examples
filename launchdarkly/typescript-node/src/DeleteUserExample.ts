import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.deleteUser(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  "userKey_string", // userKey
).catch(error => {
  console.log("Exception when calling UsersApi#deleteUser:");
  console.log(error.body);
});
