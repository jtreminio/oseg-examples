import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.UsersApi();
apiCaller.setApiKey(api.UsersApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getUsers(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  undefined, // limit
  undefined, // searchAfter
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling UsersApi#getUsers:");
  console.log(error.body);
});
